using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.DeleteOffice;

public class DeleteOfficeHandler : IRequestHandler<DeleteOfficeCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public DeleteOfficeHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository;
    }

    public async Task<ErrorOr<DoctorInfoResponse>> Handle(DeleteOfficeCommand request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;

        if (userId == null) return Errors.DoctorInfoErrors.NotLogged;

        var result = await _doctorInfoRepository.DeteleOfiice(request.Id, (Guid)userId, cancellationToken);

        if (!result) return Errors.DoctorInfoErrors.WrongOffice;

        return new DoctorInfoResponse("Pomyślnie usunięto gabinet!");
    }
}