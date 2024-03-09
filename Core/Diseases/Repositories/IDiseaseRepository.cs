using Core.Diseases.DTOS;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.Diseases.Repositories;

public interface IDiseaseRepository
{
    Task<bool> AddDisease(Guid userId, Disease disease, CancellationToken cancellationToken);
    Task<bool> UpdateDisease(Guid userId, Guid diseaseId, ToUpdateDiseaseDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteDisease(Guid doctorId, Guid diseaseId, CancellationToken cancellationToken);
    Task<List<GetPatientDiseasesDto>> GetPatientDiseases(Guid patientId, CancellationToken cancellationToken);
}