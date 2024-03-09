using Core.Diseases.DTOS;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.Diseases.Extensions;

public static class Extensions
{
    public static GetPatientDiseasesDto PatientDiseasesAsDto(this Disease diseases)
    {
        return new GetPatientDiseasesDto
        {
            Id = diseases.Id,
            Name = diseases.Name,
            Description = diseases.Description,
            Medicines = diseases.Medicines,
            Date = diseases.Date
        };
    }
}