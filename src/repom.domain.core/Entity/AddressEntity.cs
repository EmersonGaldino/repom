using System.ComponentModel.DataAnnotations.Schema;

namespace repom.domain.core.Entity;

[Table("address")]
public class AddressEntity: BaseEntity
{
    [Column("street")]
    public string Street { get; set; }
    [Column("number")]
    public string Number { get; set; }
    [Column("city")]   
    public string City { get; set; }
    [Column("zip_code")]  
    public string ZipCode { get; set; }
    [Column("complement")] 
    public string Complement { get; set; }
    [Column("state")]
    public string State { get; set; }
}