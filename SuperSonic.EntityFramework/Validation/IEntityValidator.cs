using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SuperSonic.EntityFramework.Validation
{
    public interface IEntityValidator
    {
        DbEntityValidationResult IsValid(object entity, DbContext dbContext, DbEntityValidationResult defaultResult);
    }

    public interface IEntityValidator<in TEntity> : IEntityValidator
    {
        DbEntityValidationResult IsValid(TEntity entity, DbContext dbContext, DbEntityValidationResult defaultResult);
    }
}