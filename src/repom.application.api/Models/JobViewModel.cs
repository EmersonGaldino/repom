using System.ComponentModel.DataAnnotations;

namespace repom.application.api.Models;

public class JobViewModel
{
    [Required(ErrorMessage = "Job description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Salary is required.")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Linked department is required.")]
    public DepartmentViewModel Department { get; set; }
}