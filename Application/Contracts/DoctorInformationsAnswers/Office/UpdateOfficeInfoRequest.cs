namespace Application.Contracts.DoctorInformationsAnswers.Office;

public record UpdateOfficeInfoRequest(
    string? Street,
    int? BuildingNumber,
    int? ApartamentNumber,
    string? PostalCode,
    string? City,
    string? Monday,
    string? Tuesday,
    string? Wednesday,
    string? Thursday,
    string? Fridady,
    string? Saturday,
    string? Sunday
    );