using System.Data.Entity;

namespace SuperSonic.EntityFramework.Persistence
{
    public class BasePersistenceInterceptor : IPersistenceInterceptor
    {
        public virtual void OnPreInsert(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }

        public virtual void OnPostInsert(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }

        public virtual void OnPreUpdate(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }

        public virtual void OnPostUpdate(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }

        public virtual void OnPreDelete(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }

        public virtual void OnPostDelete(DbContext dbContext, PersistanceActionArgs actionArgs)
        {
        }
    }
}