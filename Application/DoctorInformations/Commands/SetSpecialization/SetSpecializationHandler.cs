using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;
using occurrensBackend.Entities.DatabaseEntities;

namespace Application.DoctorInformations.Commands.SetSpecialization;

public class SetSpecializationHandler : IRequestHandler<SetSpecializationCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public SetSpecializationHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository;
    }
    
    public async Task<ErrorOr<DoctorInfoResponse>> Handle(SetSpecializationCommand request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;
        
        if (userId is null) return Errors.DoctorInfoErrors.NotLogged;

        var specialization = new Specialization
        {
            DoctorId = userId,
            Specjalization = request.Specialization
        };
        
        await _doctorInfoRepository.SetSpecialization(specialization, cancellationToken);

        return new DoctorInfoResponse("Utworzono nową specjalizację!");
    }
}