using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.DTOS;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Commands.EditOfficeInfo;

public class EditOfficeInfoHandler : IRequestHandler<EditOfficeInfoCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public EditOfficeInfoHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository;
    }

    public async Task<ErrorOr<DoctorInfoResponse>> Handle(EditOfficeInfoCommand request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;

        if (userId is null) return Errors.DoctorInfoErrors.NotLogged;

        var toUpdate = new ToUpdateOfficeDto
        {
            Street = request.Street,
            BuildingNumber = request.BuildingNumber ?? default(int),
            ApartamentNumber = request.ApartamentNumber ?? default(int),
            PostalCode = request.PostalCode,
            City = request.City,
            Monday = request.Monday,
            Tuesday = request.Tuesday,
            Wednesday = request.Wednesday,
            Thursday = request.Thursday,
            Fridady = request.Fridady,
            Saturday = request.Saturday,
            Sunday = request.Sunday
        };

        var result =
            await _doctorInfoRepository.UpdateOfficeInfo(toUpdate, (Guid)userId, request.Id, cancellationToken);

        if (!result) return Errors.Permision.PermissionDenied;

        return new DoctorInfoResponse("Pomyślnie zaktualizowano!");
    }
}