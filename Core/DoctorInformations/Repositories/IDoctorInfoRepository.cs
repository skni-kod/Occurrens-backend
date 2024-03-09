using Core.DoctorInformations.DTOS;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.DoctorInformations.Repositories;

public interface IDoctorInfoRepository
{
    Task SetSpecialization(Specialization specialization, CancellationToken cancellationToken);
    Task SetAddress(Address address, CancellationToken cancellationToken);
    Task<AddressDto> GetAddress(Guid addressId, CancellationToken cancellationToken);
    Task<bool> IsOpenedDataExists(Guid id, CancellationToken cancellationToken);
    Task CreateOpenedInfo(Is_opened isOpened, CancellationToken cancellationToken);
    Task<bool> UpdateSpecialization(Guid userId, Guid specializationId,string newSpecialization, CancellationToken cancellationToken);
    Task<bool> UpdateOfficeInfo(ToUpdateOfficeDto dto, Guid userId, Guid officeId, CancellationToken cancellationToken);
    Task<bool> DaleteSpecialization(Guid id, Guid doctorId, CancellationToken cancellationToken); 
    Task<bool> DeteleOfiice(Guid id, Guid userId, CancellationToken cancellationToken);
    Task<GetSelfInfoDto?> GetSelfInfo(Guid userId, CancellationToken cancellationToken);
}