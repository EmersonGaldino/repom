using System.ComponentModel.DataAnnotations;
using repom.application.api.Validation;

namespace repom.application.api.Models;

public class PersonViewModel
{
    [Required(ErrorMessage = "Full name is required.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "RG is required.")]
    public string RG { get; set; }

    [Required(ErrorMessage = "CPF is required.")]
    [ValidCpf(ErrorMessage = "Invalid CPF.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF must contain exactly 11 numeric digits.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "Birth date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public AddressViewModel Address { get; set; }

    [AtLeastOneMobilePhone]
    [Required(ErrorMessage = "At least one phone is required.")]
    public List<PhoneViewModel> Phones { get; set; }

    [Required(ErrorMessage = "Job is required.")]
    public JobViewModel Job { get; set; }
}