using System;
using System.Data;
using System.Data.Entity;

namespace SuperSonic.EntityFramework.Persistence
{
    public static class PersistenceInterceptorExtensions
    {
        public static void CallPreAction(this IPersistenceInterceptor interceptor, DbContext dbContext,
                                         PersistanceActionArgs actionArgs, EntityState state)
        {
            if (interceptor == null) throw new NullReferenceException("Interceptor cannot be null");
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            if (actionArgs == null) throw new ArgumentNullException("actionArgs");

            // Check the state of the entry and call appropriate pre-action
            switch (state)
            {
                case EntityState.Added:
                    interceptor.OnPreInsert(dbContext, actionArgs);
                    break;
                case EntityState.Modified:
                    interceptor.OnPreUpdate(dbContext, actionArgs);
                    break;
                case EntityState.Deleted:
                    interceptor.OnPreDelete(dbContext, actionArgs);
                    break;
            }
        }

        public static void CallPostAction(this IPersistenceInterceptor interceptor, DbContext dbContext,
                                          PersistanceActionArgs actionArgs, EntityState state)
        {
            if (interceptor == null) throw new NullReferenceException("Interceptor cannot be null");
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            if (actionArgs == null) throw new ArgumentNullException("actionArgs");

            // Check the state of the entry and call appropriate pre-action
            switch (state)
            {
                case EntityState.Added:
                    interceptor.OnPostInsert(dbContext, actionArgs);
                    break;
                case EntityState.Modified:
                    interceptor.OnPostUpdate(dbContext, actionArgs);
                    break;
                case EntityState.Deleted:
                    interceptor.OnPostDelete(dbContext, actionArgs);
                    break;
            }
        }
    }
}