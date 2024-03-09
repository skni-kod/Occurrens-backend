using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Commands.ResetPassword;

public record ResetPasswordCommand(
    string Token,
    string NewPassword,
    string ConfirmPassword,
    UserRoles Role
    ) : IRequest<ErrorOr<AccountResponse>>; 