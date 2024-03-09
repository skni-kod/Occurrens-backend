using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Queries.ForgotPassword;

public record ForgotPasswordQuery(
    string Email,
    UserRoles Role
    ) : IRequest<ErrorOr<AccountResponse>>; 