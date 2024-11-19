using MediatR;
using Occurrens.Application.Account.Responses;

namespace Occurrens.Application.Account.Command.ResetPassword;

public sealed record ResetPasswordCommand(
    Guid UserId,
    string Token,
    string Password,
    string RepeatPassword
) : IRequest<ResetPasswordResponse>;