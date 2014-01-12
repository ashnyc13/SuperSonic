using System;
using System.Data.Entity;

namespace SuperSonic.EntityFramework.Persistence
{
    public class BasePersistenceInterceptor<TEntity> : IPersistenceInterceptor<TEntity>, IPersistenceInterceptor
    {
        public virtual void OnPreInsert(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        public virtual void OnPostInsert(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        public virtual void OnPreUpdate(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        public virtual void OnPostUpdate(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        public virtual void OnPreDelete(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        public virtual void OnPostDelete(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs)
        {
        }

        void IPersistenceInterceptor.OnPreInsert(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPreInsert(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        void IPersistenceInterceptor.OnPostInsert(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPostInsert(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        void IPersistenceInterceptor.OnPreUpdate(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPreUpdate(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        void IPersistenceInterceptor.OnPostUpdate(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPostUpdate(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        void IPersistenceInterceptor.OnPreDelete(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPreDelete(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        void IPersistenceInterceptor.OnPostDelete(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            Validate(dbContext, actionArgs);
            OnPostDelete(dbContext, actionArgs as PersistanceActionArgs<TEntity>);
        }

        private static void Validate(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            if (actionArgs == null) throw new ArgumentNullException("actionArgs");

            if (!(actionArgs.Entity is TEntity))
                throw new InvalidOperationException(
                    "Persistence intercepter invoked with null or unsupported entity type");
        }
    }
}