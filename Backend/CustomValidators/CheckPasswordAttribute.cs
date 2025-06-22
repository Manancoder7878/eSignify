using System.ComponentModel.DataAnnotations;

namespace Backend.CustomValidators
{
    public class CheckPasswordAttribute:ValidationAttribute
    {
        private readonly string _otherproperty;
        public CheckPasswordAttribute(string otherproperty)
        {
            _otherproperty = otherproperty;
        }
        protected override ValidationResult IsValid(object? value,ValidationContext validationContext)
        {
           var confirmPassword = value as string;
            var propertyInfo = validationContext.ObjectType.GetProperty(_otherproperty);
            if (propertyInfo == null) {
                return new ValidationResult($"Unknown property: {_otherproperty}");
            }
            var password = propertyInfo.GetValue(validationContext.ObjectInstance) as string;
            if(confirmPassword != password)
            {
                return new ValidationResult("Confirm password does not match password");
            }
            return ValidationResult.Success;
        }
    }
}
