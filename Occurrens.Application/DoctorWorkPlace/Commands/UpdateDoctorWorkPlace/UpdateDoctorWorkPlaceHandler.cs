using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;
using Occurrens.Application.Persistance.Interfaces.CurrentUser;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;

namespace Occurrens.Application.DoctorWorkPlace.Commands.UpdateDoctorWorkPlace;

public class UpdateDoctorWorkPlaceHandler : IRequestHandler<UpdateDoctorWorkPlaceCommand, UpdateDoctorWorkPlaceResponse>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDoctorWorkPlaceService _doctorWorkPlaceService;

    public UpdateDoctorWorkPlaceHandler(ICurrentUserService currentUserService, IDoctorWorkPlaceService doctorWorkPlaceService)
    {
        _currentUserService = currentUserService;
        _doctorWorkPlaceService = doctorWorkPlaceService;
    }
    
    public async Task<UpdateDoctorWorkPlaceResponse> Handle(UpdateDoctorWorkPlaceCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId();
        
        var doctorWorkPlace = new Domain.Entities.DoctorWorkPlace()
        {
            Street = request.Street,
            BuildingNumber = request.BuildingNumber,
            ApartamentNumber = request.ApartamentNumber,
            PostalCode = request.PostalCode,
            City = request.City,
            LastUpdate = DateTime.Now,
            LastUpdateBy = userId
        };
        
        await _doctorWorkPlaceService.UpdateDoctorWorkPlace(doctorWorkPlace, request.WorkPlaceId, userId, cancellationToken);

        return new UpdateDoctorWorkPlaceResponse("Pomyślnie zaktualizowano");
    }
}