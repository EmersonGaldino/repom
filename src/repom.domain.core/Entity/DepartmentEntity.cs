using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

[Table("department")]
public class DepartmentEntity : BaseEntity
{
    [Column("description")]
    public string Description { get; set; }
}