using System.ComponentModel.DataAnnotations;

namespace repom.application.api.Models;

public class AddressViewModel
{
    [Required(ErrorMessage = "Street is required.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Number is required.")]
    public string Number { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }

    [RegularExpression(@"^\d{8}$", ErrorMessage = "ZIP code must contain exactly 8 numeric digits.")]
    public string ZipCode { get; set; }

    public string Complement { get; set; }

    [Required(ErrorMessage = "State is required.")]
    [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "State must be the 2-letter abbreviation (UF) in uppercase.")]
    public string State { get; set; }
}