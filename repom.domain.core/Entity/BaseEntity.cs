using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

public class BaseEntity
{
    [Key]
    public Guid id { get; set; }
    [Column("criado_em")]
    public DateTime Createat { get; set; } = DateTime.Now;
    [Column("alterado_em")]
    public DateTime UdateAt { get; set; }
}