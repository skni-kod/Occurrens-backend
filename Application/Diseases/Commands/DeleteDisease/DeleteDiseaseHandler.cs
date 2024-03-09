using Application.Common.Errors;
using Application.Contracts.DiseaseAnswer;
using Core.DataFromClaims.UserId;
using Core.Diseases.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseHandler : IRequestHandler<DeleteDiseaseCommand, ErrorOr<DiseaseResponse>>
{
    private readonly IGetUserId _getUserIdl;
    private readonly IDiseaseRepository _diseaseRepository;

    public DeleteDiseaseHandler(IGetUserId getUserId, IDiseaseRepository diseaseRepository)
    {
        _getUserIdl = getUserId;
        _diseaseRepository = diseaseRepository; 
    }
    
    public async Task<ErrorOr<DiseaseResponse>> Handle(DeleteDiseaseCommand request, CancellationToken cancellationToken)
    {
        var doctorId = _getUserIdl.UserId;

        if (doctorId is null) return Errors.DiseaseErrors.NotLogged;

        var response = await _diseaseRepository.DeleteDisease((Guid)doctorId, request.DiseaseId, cancellationToken);

        if (!response) return Errors.DiseaseErrors.WrongDisease; 

        return new DiseaseResponse("Usunięto!");
    }
}