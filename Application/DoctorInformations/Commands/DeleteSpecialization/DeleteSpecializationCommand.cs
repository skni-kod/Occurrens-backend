using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.DeleteSpecialization;

public record DeleteSpecializationCommand(
    Guid Id
    ) : IRequest<ErrorOr<DoctorInfoResponse>>; 