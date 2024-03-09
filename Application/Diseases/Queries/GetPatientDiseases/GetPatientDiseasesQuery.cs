using Application.Contracts.DiseaseAnswer;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Queries.GetPatientDiseases;

public record GetPatientDiseasesQuery(Guid PatientId) : IRequest<ErrorOr<GetPatientDiseasesResponse>>;