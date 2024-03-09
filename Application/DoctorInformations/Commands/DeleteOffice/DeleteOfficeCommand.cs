using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.DeleteOffice;

public record DeleteOfficeCommand(
    Guid Id
    ) : IRequest<ErrorOr<DoctorInfoResponse>>;