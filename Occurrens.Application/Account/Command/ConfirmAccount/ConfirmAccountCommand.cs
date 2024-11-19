using MediatR;
using Occurrens.Application.Account.Responses;

namespace Occurrens.Application.Account.Command.ConfirmAccount;

public sealed record ConfirmAccountCommand(
    Guid UserId,
    string Token
) : IRequest<ConfirmAccountResponse>;