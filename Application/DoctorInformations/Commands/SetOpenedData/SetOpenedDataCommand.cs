using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.SetOpenedData;

public record SetOpenedDataCommand(
    string? Monday,
    string? Tuesday,
    string? Wednesday,
    string? Thursday,
    string? Fridady,
    string? Saturday,
    string? Sunday,
    Guid AddressId
    ) : IRequest<ErrorOr<DoctorInfoResponse>>; 