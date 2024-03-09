using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.EditSpecialization;

public record EditSpecializationCommand(
    Guid Id,
    string NewSpecialization
    ) : IRequest<ErrorOr<DoctorInfoResponse>>;