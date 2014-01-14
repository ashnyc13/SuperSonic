using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace SuperSonic.EntityFramework.Validation
{
    public interface IEntityValidator
    {
        DbEntityValidationResult IsValid(DbEntityEntry entityEntry, DbContext dbContext, DbEntityValidationResult defaultResult);
    }

    public interface IEntityValidator<TEntity> : IEntityValidator where TEntity : class
    {
        DbEntityValidationResult IsValid(DbEntityEntry<TEntity> entityEntry, DbContext dbContext, DbEntityValidationResult defaultResult);
    }
}