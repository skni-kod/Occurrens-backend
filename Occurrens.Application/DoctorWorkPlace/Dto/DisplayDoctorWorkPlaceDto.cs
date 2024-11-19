namespace Occurrens.Application.DoctorWorkPlace.Dto;

public class DisplayDoctorWorkPlaceDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int? ApartamentNumber { get; set; } = null;
    public string PostalCode { get; set; }
    public string City { get; set; }
}