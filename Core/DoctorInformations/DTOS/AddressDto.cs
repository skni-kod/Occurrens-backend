namespace Core.DoctorInformations.DTOS;

public class AddressDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int Building_number { get; set; }
    public int Apartament_number { get; set; }
    public string Postal_code { get; set; }
    public string City { get; set; }
    public Guid DoctorId { get; set; } 
}