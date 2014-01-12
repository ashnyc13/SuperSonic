using System.Data.Entity;

namespace SuperSonic.EntityFramework.Persistence
{
    public interface IPersistenceInterceptor
    {
        void OnPreInsert(DbContext dbContext, PersistanceActionArgs actionArgs);
        void OnPostInsert(DbContext dbContext, PersistanceActionArgs actionArgs);
        void OnPreUpdate(DbContext dbContext, PersistanceActionArgs actionArgs);
        void OnPostUpdate(DbContext dbContext, PersistanceActionArgs actionArgs);
        void OnPreDelete(DbContext dbContext, PersistanceActionArgs actionArgs);
        void OnPostDelete(DbContext dbContext, PersistanceActionArgs actionArgs);
    }

    public interface IPersistenceInterceptor<TEntity>
    {
        void OnPreInsert(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
        void OnPostInsert(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
        void OnPreUpdate(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
        void OnPostUpdate(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
        void OnPreDelete(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
        void OnPostDelete(DbContext dbContext, PersistanceActionArgs<TEntity> actionArgs);
    }
}