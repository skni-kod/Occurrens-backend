namespace Occurrens.Domain.Entities;

public class DoctorWorkPlace : BaseEntity
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int? ApartamentNumber { get; set; } = null;
    public string PostalCode { get; set; }
    public string City { get; set; }
    
    public Guid? AccountId { get; set; }
    public Account Account { get; set; }
}