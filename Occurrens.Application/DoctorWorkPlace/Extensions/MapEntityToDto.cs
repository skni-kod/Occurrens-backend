using Occurrens.Application.DoctorWorkPlace.Dto;

namespace Occurrens.Application.DoctorWorkPlace.Extensions;

public static class MapEntityToDto
{
    public static DisplayDoctorWorkPlaceDto DoctorWorkPlaceAsDto(this Domain.Entities.DoctorWorkPlace doctorWorkPlace)
    {
        return new DisplayDoctorWorkPlaceDto
        {
            Id = doctorWorkPlace.Id,
            Street = doctorWorkPlace.Street,
            BuildingNumber = doctorWorkPlace.BuildingNumber,
            ApartamentNumber = doctorWorkPlace.ApartamentNumber,
            PostalCode = doctorWorkPlace.PostalCode,
            City = doctorWorkPlace.City
        };
    }
}