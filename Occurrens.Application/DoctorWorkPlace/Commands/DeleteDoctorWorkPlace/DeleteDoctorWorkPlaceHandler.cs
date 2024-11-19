using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;
using Occurrens.Application.Persistance.Interfaces.CurrentUser;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;

namespace Occurrens.Application.DoctorWorkPlace.Commands.DeleteDoctorWorkPlace;

public class DeleteDoctorWorkPlaceHandler : IRequestHandler<DeleteDoctorWorkPlaceCommand, DeleteDoctorWorkPlaceResponse>
{
    private readonly IDoctorWorkPlaceService _doctorWorkPlaceService;
    private readonly ICurrentUserService _currentUserService;

    public DeleteDoctorWorkPlaceHandler(IDoctorWorkPlaceService doctorWorkPlaceService, ICurrentUserService currentUserService)
    {
        _doctorWorkPlaceService = doctorWorkPlaceService;
        _currentUserService = currentUserService;
    }
    
    public async Task<DeleteDoctorWorkPlaceResponse> Handle(DeleteDoctorWorkPlaceCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId();

        await _doctorWorkPlaceService.DeleteDoctorWorkPlace(request.DoctorPlaceId, userId, cancellationToken);

        return new DeleteDoctorWorkPlaceResponse("Sukces!");
    }
}