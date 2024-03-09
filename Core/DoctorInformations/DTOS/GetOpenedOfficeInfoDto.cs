namespace Core.DoctorInformations.DTOS;

public class GetOpenedOfficeInfoDto
{
    public Guid Id { get; set; }
    public string Monday { get; set; }
    public string Tuesday { get; set; } 
    public string Wednesday { get; set; }
    public string Thursday { get; set; } 
    public string Fridady { get; set; }
    public string Saturday { get; set; }
    public string Sunday { get; set; }
}