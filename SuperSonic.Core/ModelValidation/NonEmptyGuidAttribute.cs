using System;
using System.ComponentModel.DataAnnotations;

namespace SuperSonic.Core.ModelValidation
{
    public class NonEmptyGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is Guid)) return ValidationResult.Success;
            var guid = (Guid) value;
            return guid == Guid.Empty
                       ? new ValidationResult(string.Format("{0} cannot be an Empty Guid", validationContext.MemberName))
                       : ValidationResult.Success;
        }
    }
}