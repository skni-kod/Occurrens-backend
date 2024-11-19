using MediatR;
using Occurrens.Application.Account.Responses;
using Occurrens.Application.Persistance.Interfaces.Account;

namespace Occurrens.Application.Account.Command.ResetPassword;

public sealed class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    private readonly IAccountService _accountService;

    public ResetPasswordHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _accountService.ResetPasswordAsync(request.Token, request.UserId, request.Password, cancellationToken);

        return new ResetPasswordResponse("Success!");
    }
}