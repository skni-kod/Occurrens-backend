using Core.Diseases.DTOS;

namespace Application.Contracts.DiseaseAnswer;

public record GetPatientDiseasesResponse( List<GetPatientDiseasesDto?> data );