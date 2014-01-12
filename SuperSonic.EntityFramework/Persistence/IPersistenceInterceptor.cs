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
}