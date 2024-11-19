using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;

namespace Occurrens.Application.DoctorWorkPlace.Commands.UpdateDoctorWorkPlace;

public record UpdateDoctorWorkPlaceCommand(
    Guid WorkPlaceId,
    string Street,
    int BuildingNumber,
    int? ApartamentNumber,
    string PostalCode,
    string City
    ) : IRequest<UpdateDoctorWorkPlaceResponse>;