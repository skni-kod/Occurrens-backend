using Core.DoctorInformations.DTOS;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.DoctorInformations.Extensions;

public static class Extensions
{
    public static AddressDto AddressAsDto(this Address address)
    {
        return new AddressDto
        {
            DoctorId = (Guid)address.DoctorId,
            Id = address.Id,
            Street = address.Street,
            Building_number = address.Building_number,
            Apartament_number = (int)address.Apartament_number,
            Postal_code = address.Postal_code,
            City = address.City,
        };
    }

    private static GetOpenedOfficeInfoDto OpenedInfoAsDto(this Is_opened isOpened)
    {
        return new GetOpenedOfficeInfoDto
        {
            Id = isOpened.Id,
            Monday = isOpened.Monday,
            Tuesday = isOpened.Tuesday,
            Wednesday = isOpened.Wednesday,
            Thursday = isOpened.Thursday,
            Fridady = isOpened.Fridady,
            Saturday = isOpened.Saturday,
            Sunday = isOpened.Sunday
        };
    }

    private static GetOfficeInfoDto OfficeInfoAsDto(this Address address)
    {
        var openedInfo = new List<GetOpenedOfficeInfoDto>();

        foreach (var opened in address.is_opened)
        {
            openedInfo.Add(opened.OpenedInfoAsDto());
        }

        return new GetOfficeInfoDto
        {
            Id = address.Id,
            Street = address.Street,
            Building_number = address.Building_number,
            Apartament_number = address.Apartament_number,
            Postal_code = address.Postal_code,
            City = address.City,
            Opened = openedInfo 
        };
    }

    public static GetSelfInfoDto SelfInfoAsDto(this Doctor doctor)
    {
        var officesList = new List<GetOfficeInfoDto>();
        var specializationList = new List<string>();

        foreach (var offices in doctor.addresses)
        {
            officesList.Add(offices.OfficeInfoAsDto());
        }

        foreach (var specialization in doctor.spetializations)
        {
            specializationList.Add(specialization.Specjalization);
        }

        return new GetSelfInfoDto
        {
            Id = doctor.Id,
            Pesel = doctor.Pesel,
            Name = doctor.Name,
            Secont_name = doctor.Secont_name,
            Last_name = doctor.Last_name,
            Telephon_number = doctor.Telephon_number,
            Email = doctor.Email,
            Date_of_birth = doctor.Date_of_birth,
            Specializations = specializationList,
            Offices = officesList
        };
    }
}