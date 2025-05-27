using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace repom.application.api.Validation;

public class ValidCpfAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var cpf = value as string;

        if (string.IsNullOrWhiteSpace(cpf))
            return new ValidationResult("CPF is required.");

        cpf = Regex.Replace(cpf, @"[^\d]", "");

        if (cpf.Length != 11)
            return new ValidationResult("CPF must contain exactly 11 digits.");

        var invalidCpfs = new[]
        {
            "00000000000", "11111111111", "22222222222", "33333333333",
            "44444444444", "55555555555", "66666666666", "77777777777",
            "88888888888", "99999999999"
        };

        if (invalidCpfs.Contains(cpf))
            return new ValidationResult("CPF is invalid.");

        var digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        var sum = 0;
        for (int i = 0; i < 9; i++)
            sum += digits[i] * (10 - i);

        var remainder = sum % 11;
        var firstVerifier = remainder < 2 ? 0 : 11 - remainder;
        if (digits[9] != firstVerifier)
            return new ValidationResult("CPF is invalid.");

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += digits[i] * (11 - i);

        remainder = sum % 11;
        var secondVerifier = remainder < 2 ? 0 : 11 - remainder;
        if (digits[10] != secondVerifier)
            return new ValidationResult("CPF is invalid.");

        return ValidationResult.Success;
    }
}