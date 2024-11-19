using MediatR;
using Occurrens.Application.Persistance.Interfaces.Account;

namespace Occurrens.Application.Account.Command.SignOut;

public sealed class SignOutHandler : IRequestHandler<SignOutCommand>
{
    private readonly IAccountService _accountService;
    
    public SignOutHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    public async Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        await _accountService.SignOut(request.RefreshToken, cancellationToken);
    }
}