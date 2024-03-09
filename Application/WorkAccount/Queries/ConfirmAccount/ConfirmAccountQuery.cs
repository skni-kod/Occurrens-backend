using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Queries.ConfirmAccount;

public record ConfirmAccountQuery(
    string Token,
    UserRoles Role,
    Guid Id
    ) : IRequest<ErrorOr<AccountResponse>>;