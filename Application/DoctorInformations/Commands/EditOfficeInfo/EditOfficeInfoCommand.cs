using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.EditOfficeInfo;

public record EditOfficeInfoCommand(
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
    string? Sunday,
    Guid Id
    ) : IRequest<ErrorOr<DoctorInfoResponse>>;