using Application.Common.Errors;
using Application.Contracts.DoctorInformationsAnswers;
using Core.DataFromClaims.UserId;
using Core.DoctorInformations.Repositories;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Queries.GetSelfInfo;

public class GetSelfInfoHandler : IRequestHandler<GetSelfInfoQuery, ErrorOr<GetSelfInfoResponse>>
{
    private readonly IGetUserId _getUserId;
    private readonly IDoctorInfoRepository _doctorInfoRepository;

    public GetSelfInfoHandler(IGetUserId getUserId, IDoctorInfoRepository doctorInfoRepository)
    {
        _getUserId = getUserId;
        _doctorInfoRepository = doctorInfoRepository;
    }

    public async Task<ErrorOr<GetSelfInfoResponse>> Handle(GetSelfInfoQuery request, CancellationToken cancellationToken)
    {
        var userId = _getUserId.UserId.Value;

        if (userId == null) return Errors.DoctorInfoErrors.NotLogged; 
        
        var response = await _doctorInfoRepository.GetSelfInfo((Guid)userId, cancellationToken);

        if (response == null) return Errors.DoctorInfoErrors.NotDataToDisplay;

        return new GetSelfInfoResponse(response);
    }
}