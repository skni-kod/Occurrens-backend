namespace Core.DoctorInformations.DTOS;

public class GetSelfInfoDto
{
    public Guid Id { get; set; }
    public long Pesel { get; set; }
    public string Name { get; set; }
    public string? Secont_name { get; set; }
    public string Last_name { get; set; }
    public int Telephon_number { get; set; }
    public string Email { get; set; }
    public DateOnly Date_of_birth { get; set; }
    public List<string> Specializations { get; set; }
    public List<GetOfficeInfoDto> Offices { get; set; }
}