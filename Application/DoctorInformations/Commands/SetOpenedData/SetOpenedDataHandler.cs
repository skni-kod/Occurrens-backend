using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.Account.Repositories;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;
using occurrensBackend.Entities.DatabaseEntities;

namespace Application.DoctorInformations.Commands.SetOpenedData;

public class SetOpenedDataHandler : IRequestHandler<SetOpenedDataCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public SetOpenedDataHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository;
    }
    
    public async Task<ErrorOr<DoctorInfoResponse>> Handle(SetOpenedDataCommand request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;
        
        if (userId is null) return Errors.DoctorInfoErrors.NotLogged;

        var address = await _doctorInfoRepository.GetAddress(request.AddressId, cancellationToken);

        if (address is null) return Errors.DoctorInfoErrors.WrongAddressId;

        if (address.DoctorId != userId) return Errors.DoctorInfoErrors.NotAccess;

        var isOpenedDataExist = await _doctorInfoRepository.IsOpenedDataExists(address.Id, cancellationToken);

        if (isOpenedDataExist == true) return Errors.DoctorInfoErrors.DataExists;

        var openedData = new Is_opened
        {
            AddressId = address.Id,
            Monday = request.Monday ?? "Zamknięte",
            Tuesday = request.Tuesday ?? "Zamknięte",
            Wednesday = request.Wednesday ?? "Zamknięte",
            Thursday = request.Thursday ?? "Zamknięte",
            Fridady = request.Fridady ?? "Zamknięte",
            Saturday = request.Saturday ?? "Zamknięte",
            Sunday = request.Sunday ?? "Zamknięte"
        };

        await _doctorInfoRepository.CreateOpenedInfo(openedData, cancellationToken);

        return new DoctorInfoResponse("Sukces!");
    }
}