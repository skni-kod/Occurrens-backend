using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;

namespace Occurrens.Application.DoctorWorkPlace.Queries.GetWorkPlacesForSpecificDoctor;

public record GetWorkPlacesForSpecificDoctorQuery(
    Guid DoctorId
    ) : IRequest<GetWorkPlacesForSpecificDoctorResponse>;