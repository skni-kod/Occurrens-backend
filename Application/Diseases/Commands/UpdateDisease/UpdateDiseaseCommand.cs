using Application.Contracts.DiseaseAnswer;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Commands.UpdateDisease;

public record UpdateDiseaseCommand(
    Guid DiseaseId,
    string? Name,
    string? Description,
    string? Medicines
    ) : IRequest<ErrorOr<DiseaseResponse>>;