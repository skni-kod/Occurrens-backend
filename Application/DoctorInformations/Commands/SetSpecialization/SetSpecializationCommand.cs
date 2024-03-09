using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.SetSpecialization;

public record SetSpecializationCommand(
    string Specialization
    ) : IRequest<ErrorOr<DoctorInfoResponse>>; 