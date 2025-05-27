using System.ComponentModel.DataAnnotations;

namespace repom.application.api.Models;

public class DepartmentViewModel
{
    [Required(ErrorMessage = "Sector description is required.")]
    public string Description { get; set; }
}