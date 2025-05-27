using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

public class BaseEntity
{
    [Key]
    public int id { get; set; }
    [Column("created_at")]
    public DateTime Createat { get; set; } = DateTime.UtcNow;
    [Column("updated_at")]
    public DateTime UdateAt { get; set; }
}