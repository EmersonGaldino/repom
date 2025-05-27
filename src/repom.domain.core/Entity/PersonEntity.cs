using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

[Table("person")]
public class PersonEntity : BaseEntity
{
    [Column("full_name")]
    public string FullName { get; set; }
    [Column("rg")]
    public string RG { get; set; }
    [Column("cpf")]
    public string CPF { get; set; }
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    [Column("address_id")]
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; }
  
    public List<PhoneEntity> Phones { get; set; }
    [Column("job_id")]
    public int JobId { get; set; }
    public JobEntity Job { get; set; }
}