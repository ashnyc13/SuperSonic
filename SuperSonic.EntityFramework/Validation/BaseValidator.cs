using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace SuperSonic.EntityFramework.Validation
{
    public abstract class BaseValidator<TEntity> : IEntityValidator<TEntity> where TEntity : class
    {
        public abstract DbEntityValidationResult IsValid(DbEntityEntry<TEntity> entityEntry, DbContext dbContext,
                                                         DbEntityValidationResult defaultResult);

        public virtual DbEntityValidationResult IsValid(DbEntityEntry entityEntry, DbContext dbContext,
                                                        DbEntityValidationResult defaultResult)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            if (defaultResult == null) throw new ArgumentNullException("defaultResult");
            if (!(entityEntry.Entity is TEntity))
                throw new InvalidOperationException("Validator invoked with null or unsupported entity type");

            return IsValid(entityEntry.Cast<TEntity>(), dbContext, defaultResult);
        }
    }
}