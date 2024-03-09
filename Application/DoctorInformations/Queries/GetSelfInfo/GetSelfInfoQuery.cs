using Application.Contracts.DoctorInformationsAnswers;
using ErrorOr;
using MediatR;

namespace Application.DoctorInformations.Queries.GetSelfInfo;

public record GetSelfInfoQuery() : IRequest<ErrorOr<GetSelfInfoResponse>>;