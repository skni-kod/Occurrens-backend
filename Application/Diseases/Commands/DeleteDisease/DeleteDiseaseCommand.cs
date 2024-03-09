using Application.Contracts.DiseaseAnswer;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Commands.DeleteDisease;

public record DeleteDiseaseCommand(
    Guid DiseaseId
    ) : IRequest<ErrorOr<DiseaseResponse>>; 