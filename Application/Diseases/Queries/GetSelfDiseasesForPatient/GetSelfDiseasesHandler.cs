using Application.Common.Errors;
using Application.Contracts.DiseaseAnswer;
using Core.DataFromClaims.UserId;
using Core.Diseases.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Queries.GetSelfDiseasesForPatient;

public class GetSelfDiseasesHandler : IRequestHandler<GetSelfDiseasesQuery, ErrorOr<GetPatientDiseasesResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDiseaseRepository _diseaseRepository;

    public GetSelfDiseasesHandler(IGetUserId getUserId, IDiseaseRepository diseaseRepository)
    {
        _getUserId = getUserId;
        _diseaseRepository = diseaseRepository; 
    }
    
    public async Task<ErrorOr<GetPatientDiseasesResponse>> Handle(GetSelfDiseasesQuery request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;

        var result = await _diseaseRepository.GetPatientDiseases((Guid)userId, cancellationToken);

        if (result == null) return Errors.DiseaseErrors.NothingToDisplay; 

        return new GetPatientDiseasesResponse(result);
    }
}