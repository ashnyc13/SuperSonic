using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using SuperSonic.EntityFramework.Validation;

namespace SuperSonic.EntityFramework.Persistence
{
    /// <summary>
    ///     Provides support for intercepting validation persistance processes
    ///     via two protected dictionaries - Validators and PersistenceInterceptors
    /// </summary>
    public class InterceptingDbContext : DbContext
    {
        protected static readonly IDictionary<string, IEntityValidator> Validators =
            new Dictionary<string, IEntityValidator>();

        protected static readonly IDictionary<string, IPersistenceInterceptor> PersistenceInterceptors =
            new Dictionary<string, IPersistenceInterceptor>();

        public InterceptingDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry,
                                                                   IDictionary<object, object> items)
        {
            var baseResult = base.ValidateEntity(entityEntry, items);
            if (!baseResult.IsValid) return baseResult;

            // Check with the validators
            var entityTypeName = entityEntry.Entity.GetType().FullName;
            if (Validators.ContainsKey(entityTypeName))
            {
                var validator = Validators[entityTypeName];
                return validator.IsValid(entityEntry.Entity, this, baseResult);
            }

            // If no validator registered, use base result
            return baseResult;
        }

        public override int SaveChanges()
        {
            // Check if there are any validation errors
            var hasValidationErrors = Configuration.ValidateOnSaveEnabled &&
                                      ChangeTracker.Entries().Any(entry => !entry.GetValidationResult().IsValid);

            // Record entities and the states they're in before saving
            var entityModifications =
                ChangeTracker.Entries()
                             .Where(entry => entry.State != EntityState.Unchanged && entry.State != EntityState.Detached)
                             .Select(entry => new { entry.Entity, PreSaveState = entry.State })
                             .ToArray();

            // Call pre-action interceptors only if there are no validation errors
            if (!hasValidationErrors)
            {
                FireInterceptors(entityModifications,
                                         (interceptor, args, entityState) =>
                                         interceptor.CallPreAction(this, args, entityState));
            }

            // Perform save action
            var baseResult = base.SaveChanges();

            // Call-post interceptors for each entity that had modifications
            FireInterceptors(entityModifications,
                                     (interceptor, args, entityState) =>
                                     interceptor.CallPostAction(this, args, entityState));

            return baseResult;
        }

        private static void FireInterceptors(IEnumerable<dynamic> entityModifications,
                                                      Action<
                                                        IPersistenceInterceptor,
                                                        PersistanceActionArgs,
                                                        EntityState> interceptorMethod)
        {
            // Go through each modified entity to fire up interceptors
            foreach (var modification in entityModifications)
            {
                // Check if we have interceptor enabled for this entity type
                var entityTypeName = modification.Entity.GetType().FullName;
                if (!PersistenceInterceptors.ContainsKey(entityTypeName)) continue;

                // Prepare action arguments
                var argsType = typeof (PersistanceActionArgs<>).MakeGenericType(modification.Entity.GetType());
                var args = Activator.CreateInstance(argsType) as PersistanceActionArgs;
// ReSharper disable PossibleNullReferenceException
                args.Entity = modification.Entity;
// ReSharper restore PossibleNullReferenceException

                // Call the appropriate method on interceptor based on entry state
                var interceptor = PersistenceInterceptors[entityTypeName];
                interceptorMethod(interceptor, args, modification.PreSaveState);
            }
        }
    }
}