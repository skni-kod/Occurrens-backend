using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.DeleteSpecialization;

public class DeleteSpecializationHandler : IRequestHandler<DeleteSpecializationCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public DeleteSpecializationHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository; 
    }

    public async Task<ErrorOr<DoctorInfoResponse>> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
    {
        var doctorId = _getUserId.UserId;

        if (doctorId is null) return Errors.DoctorInfoErrors.NotLogged;

        var result = await _doctorInfoRepository.DaleteSpecialization(request.Id, (Guid)doctorId, cancellationToken);

        if (!result) return Errors.DoctorInfoErrors.WrongSpecializationId; 

        return new DoctorInfoResponse("Pomyślnie usunięto specjalizację!");
    }
}