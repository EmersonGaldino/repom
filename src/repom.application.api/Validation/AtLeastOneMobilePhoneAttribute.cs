using System.ComponentModel.DataAnnotations;
using repom.application.api.Models;

namespace repom.application.api.Validation;

public class AtLeastOneMobilePhoneAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var telefones = value as List<PhoneViewModel>;
        if (telefones == null || !telefones.Any(t => t.Type == "Mobile"))
            return new ValidationResult("Pelo menos um telefone do tipo 'Celular' é obrigatório.");

        return ValidationResult.Success;
    }
}