namespace Core.DoctorInformations.DTOS;

public class GetOfficeInfoDto
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int Building_number { get; set; }
    public int? Apartament_number { get; set; }
    public string Postal_code { get; set; }
    public string City { get; set; }
    public List<GetOpenedOfficeInfoDto> Opened { get; set; }
}