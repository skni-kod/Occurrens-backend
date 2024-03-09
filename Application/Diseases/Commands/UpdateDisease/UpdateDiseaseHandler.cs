using Application.Common.Errors;
using Application.Contracts.DiseaseAnswer;
using Core.DataFromClaims.UserId;
using Core.Diseases.DTOS;
using Core.Diseases.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Diseases.Commands.UpdateDisease;

public class UpdateDiseaseHandler : IRequestHandler<UpdateDiseaseCommand, ErrorOr<DiseaseResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDiseaseRepository _diseaseRepository;

    public UpdateDiseaseHandler(IGetUserId getUserId, IDiseaseRepository diseaseRepository)
    {
        _getUserId = getUserId;
        _diseaseRepository = diseaseRepository;
    }
    
    public async Task<ErrorOr<DiseaseResponse>> Handle(UpdateDiseaseCommand request, CancellationToken cancellationToken)
    {
        var doctorId = _getUserId.UserId;

        if (doctorId is null) return Errors.DiseaseErrors.NotLogged;

        var toUpdate = new ToUpdateDiseaseDto
        {
            Name = request.Name,
            Description = request.Description,
            Medicines = request.Medicines
        };

        var result =
            await _diseaseRepository.UpdateDisease((Guid)doctorId, request.DiseaseId, toUpdate, cancellationToken);

        if (!result) return Errors.DiseaseErrors.WrongPatient;

        return new DiseaseResponse("Pomyślnie zmieniono dane choroby!");
    }
}