using System;
using System.ComponentModel.DataAnnotations;
using UIJobsAPI.Models.Enuns;

public class CursoEnumValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is CursoEnum)
        {
            CursoEnum enumValue = (CursoEnum)value;
            // Verifique se o valor do enum está entre os valores válidos
            if (Enum.IsDefined(typeof(CursoEnum), enumValue))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
        return new ValidationResult(ErrorMessage);
    }
}