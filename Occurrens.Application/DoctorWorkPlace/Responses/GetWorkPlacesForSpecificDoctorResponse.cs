using Occurrens.Application.DoctorWorkPlace.Dto;

namespace Occurrens.Application.DoctorWorkPlace.Responses;

public record GetWorkPlacesForSpecificDoctorResponse(List<DisplayDoctorWorkPlaceDto> WorkPlaces);