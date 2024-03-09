using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.SetAddress;

public record SetAddressCommand(
    string Street,
    int BuildingNumber,
    int? ApartamentNumber,
    string PostalCode,
    string City
    ) : IRequest<ErrorOr<DoctorInfoResponse>>;