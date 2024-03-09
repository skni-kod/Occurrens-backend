using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;
using occurrensBackend.Entities.DatabaseEntities;

namespace Application.DoctorInformations.Commands.SetAddress;

public class SetAddressHandler : IRequestHandler<SetAddressCommand, ErrorOr<DoctorInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public SetAddressHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository; 
    }
    
    public async Task<ErrorOr<DoctorInfoResponse>> Handle(SetAddressCommand request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId;
        
        if (userId is null) return Errors.DoctorInfoErrors.NotLogged;

        var address = new Address
        {
            DoctorId = userId,
            Street = request.Street, 
            Building_number = request.BuildingNumber,
            Apartament_number = request.ApartamentNumber,
            Postal_code = request.PostalCode,
            City = request.City
        };

        await _doctorInfoRepository.SetAddress(address, cancellationToken);

        return new DoctorInfoResponse("Pomyślnie dodano adres");
    }
}