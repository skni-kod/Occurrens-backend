using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;
using Occurrens.Application.Persistance.Interfaces.CurrentUser;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;

namespace Occurrens.Application.DoctorWorkPlace.Commands.AddDoctorWorkPlace;

public class AddDoctorWorkPlaceHandler : IRequestHandler<AddDoctorWorkPlaceCommand, AddDoctorWorkPlaceResponse>
{
    private readonly IDoctorWorkPlaceService _doctorWorkPlaceService;
    private readonly ICurrentUserService _currentUserService;

    public AddDoctorWorkPlaceHandler(IDoctorWorkPlaceService doctorWorkPlaceService, ICurrentUserService currentUserService)
    {
        _doctorWorkPlaceService = doctorWorkPlaceService;
        _currentUserService = currentUserService;
    }
    
    public async Task<AddDoctorWorkPlaceResponse> Handle(AddDoctorWorkPlaceCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId();
        
        var doctorWorkPlace = new Domain.Entities.DoctorWorkPlace()
        {
            Street = request.Street,
            BuildingNumber = request.BuildingNumber,
            ApartamentNumber = request.ApartamentNumber,
            PostalCode = request.PostalCode,
            City = request.City,
            CreateDate = DateTime.Now,
            CreatedBy = userId,
            LastUpdate = DateTime.Now,
            LastUpdateBy = userId
        };

        var workPlaceId = await _doctorWorkPlaceService.AddDoctorWorkPlace(doctorWorkPlace, cancellationToken);

        return new AddDoctorWorkPlaceResponse("Utworzono miejsze pracy",workPlaceId);
    }
}