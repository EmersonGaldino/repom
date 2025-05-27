using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

[Table("phone")]
public class PhoneEntity : BaseEntity
{
    [Column("number")]
    public string Number { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("person_id")]
    public int PersonId { get; set; }
    public PersonEntity Person { get; set; }

}