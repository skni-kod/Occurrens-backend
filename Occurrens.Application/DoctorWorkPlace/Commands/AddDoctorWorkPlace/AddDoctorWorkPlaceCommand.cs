using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;

namespace Occurrens.Application.DoctorWorkPlace.Commands.AddDoctorWorkPlace;

public record AddDoctorWorkPlaceCommand(
    string Street,
    int BuildingNumber,
    int? ApartamentNumber,
    string PostalCode,
    string City
    ) : IRequest<AddDoctorWorkPlaceResponse>;