using System.ComponentModel.DataAnnotations;

namespace repom.application.api.Models;

public class PhoneViewModel
{
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Phone number must contain 10 or 11 numeric digits.")]
    public string Number { get; set; }

    [Required(ErrorMessage = "Phone type is required.")]
    [RegularExpression(@"^(Mobile|Home)$", ErrorMessage = "Phone type must be 'Mobile' or 'Home'.")]
    public string Type { get; set; }
}