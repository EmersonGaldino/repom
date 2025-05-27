using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

[Table("job")]
public class JobEntity : BaseEntity
{
    [Column("description")]
    public string Description { get; set; }
    [Column("salary")]
    public decimal Salary { get; set; }
    [Column("start_date")]
    public DateTime  StartDate { get; set; }
    [Column("end_date")]   
    public DateTime EndDate { get; set; }
    [Column("department_id")] 
    public int departmentId { get; set; }
    public DepartmentEntity Department { get; set; }
}