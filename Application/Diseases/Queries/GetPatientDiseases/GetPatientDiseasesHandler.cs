using Application.Common.Errors;
using Application.Contracts.DiseaseAnswer;
using Core.Diseases.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Queries.GetPatientDiseases;

public class GetPatientDiseasesHandler : IRequestHandler<GetPatientDiseasesQuery, ErrorOr<GetPatientDiseasesResponse>>
{
    private readonly IDiseaseRepository _diseaseRepository;

    public GetPatientDiseasesHandler(IDiseaseRepository diseaseRepository)
    {
        _diseaseRepository = diseaseRepository;
    }
    
    public async Task<ErrorOr<GetPatientDiseasesResponse>> Handle(GetPatientDiseasesQuery request, CancellationToken cancellationToken)
    {
        var result = await _diseaseRepository.GetPatientDiseases(request.PatientId, cancellationToken);

        if (result == null) return Errors.DiseaseErrors.NothingToDisplay;

        return new GetPatientDiseasesResponse(result);
    }
}