using Application.Common.Errors;
using Application.Contracts.DiseaseAnswer;
using Core.DataFromClaims.UserId;
using Core.Diseases.Repositories;
using ErrorOr;
using MediatR;
using occurrensBackend.Entities.DatabaseEntities;

namespace Application.Diseases.Commands.AddDisease;

public class AddDiseaseHandler : IRequestHandler<AddDiseaseCommand, ErrorOr<DiseaseResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDiseaseRepository _diseaseRepository;

    public AddDiseaseHandler(IGetUserId getUserId, IDiseaseRepository diseaseRepository)
    {
        _getUserId = getUserId;
        _diseaseRepository = diseaseRepository; 
    }

    public async Task<ErrorOr<DiseaseResponse>> Handle(AddDiseaseCommand request, CancellationToken cancellationToken)
    {
        var doctorId = _getUserId.UserId;

        if (doctorId is null) return Errors.DiseaseErrors.NotLogged;

        var newDisease = new Disease
        {
            CreatedByDoctor = (Guid)doctorId,
            PatientId = request.PatientId,
            Name = request.Name,
            Description = request.Description,
            Medicines = request.Medicines 
        };

        var result = await _diseaseRepository.AddDisease((Guid)doctorId, newDisease, cancellationToken);

        if (!result) return Errors.DiseaseErrors.PatientNotExist;

        return new DiseaseResponse("Dodano opis medyczny poprawnie!");
    }
}