namespace Core.DoctorInformations.DTOS;

public class ToUpdateOfficeDto
{
    public string? Street { get; set; }
    public int? BuildingNumber { get; set; }
    public int? ApartamentNumber { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Monday { get; set; }
    public string? Tuesday { get; set; }
    public string? Wednesday { get; set; } 
    public string? Thursday { get; set; }
    public string? Fridady { get; set; }
    public string? Saturday { get; set; }
    public string? Sunday { get; set; }
}