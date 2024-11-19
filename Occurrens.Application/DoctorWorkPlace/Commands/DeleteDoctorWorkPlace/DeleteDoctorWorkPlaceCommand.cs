using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;

namespace Occurrens.Application.DoctorWorkPlace.Commands.DeleteDoctorWorkPlace;

public record DeleteDoctorWorkPlaceCommand(
    Guid DoctorPlaceId
    ) : IRequest<DeleteDoctorWorkPlaceResponse>;