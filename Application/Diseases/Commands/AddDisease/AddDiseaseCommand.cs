using Application.Contracts.DiseaseAnswer;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Commands.AddDisease;

public record AddDiseaseCommand(
    Guid PatientId,
    string Name,
    string Description,
    string Medicines) : IRequest<ErrorOr<DiseaseResponse>>;