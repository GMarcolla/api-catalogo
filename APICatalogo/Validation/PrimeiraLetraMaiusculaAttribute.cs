using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string strValue && !string.IsNullOrEmpty(strValue))
            {
                if (char.IsUpper(strValue[0]))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("A primeira letra deve ser maiúscula.");
                }
            }
            return new ValidationResult("O valor não pode ser nulo ou vazio.");
        }
    }
}
