using Application.Contracts.DiseaseAnswer;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Queries.GetSelfDiseasesForPatient;

public record GetSelfDiseasesQuery() : IRequest<ErrorOr<GetPatientDiseasesResponse>>;