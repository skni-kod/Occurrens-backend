using MediatR;
using Occurrens.Application.DoctorWorkPlace.Responses;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;

namespace Occurrens.Application.DoctorWorkPlace.Queries.GetWorkPlacesForSpecificDoctor;

public class GetWorkPlacesForSpecificDoctorHandler : IRequestHandler<GetWorkPlacesForSpecificDoctorQuery, GetWorkPlacesForSpecificDoctorResponse>
{
    private readonly IDoctorWorkPlaceService _doctorWorkPlaceService;

    public GetWorkPlacesForSpecificDoctorHandler(IDoctorWorkPlaceService doctorWorkPlaceService)
    {
        _doctorWorkPlaceService = doctorWorkPlaceService;
    }
    
    public async Task<GetWorkPlacesForSpecificDoctorResponse> Handle(GetWorkPlacesForSpecificDoctorQuery request, CancellationToken cancellationToken)
    {
        var doctorWorkPlaces = await _doctorWorkPlaceService.GetWorkPlacesForSpecificDoctor(request.DoctorId, cancellationToken);

        return new GetWorkPlacesForSpecificDoctorResponse(doctorWorkPlaces);
    }
}