using Occurrens.Application.DoctorWorkPlace.Dto;

namespace Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;

public interface IDoctorWorkPlaceService
{
    Task<Guid> AddDoctorWorkPlace(Domain.Entities.DoctorWorkPlace workPlace, CancellationToken cancellationToken);
    Task UpdateDoctorWorkPlace(Domain.Entities.DoctorWorkPlace updatedWorkPlace, Guid idPlaceToUpdate, Guid doctorId, CancellationToken cancellationToken);
    Task DeleteDoctorWorkPlace(Guid workPlaceId, Guid doctorId, CancellationToken cancellationToken);
    Task<List<DisplayDoctorWorkPlaceDto>> GetWorkPlacesForSpecificDoctor(Guid doctorId, CancellationToken cancellationToken);
}