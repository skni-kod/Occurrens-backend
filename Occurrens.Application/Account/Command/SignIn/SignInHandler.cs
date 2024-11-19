using MediatR;
using Microsoft.AspNetCore.Identity;
using Occurrens.Application.Persistance.Interfaces.Account;
using Occurrens.Domain.AuthTokens;

namespace Occurrens.Application.Account.Command.SignIn;

public sealed class SignInHandler : IRequestHandler<SignInCommand, JsonWebToken>
{
    private readonly IAccountService _accountService;
    private readonly SignInManager<Domain.Entities.Account> _signInManager;
    private readonly UserManager<Domain.Entities.Account> _userManager;

    public SignInHandler(IAccountService accountService,
        SignInManager<Domain.Entities.Account> signInManager,
        UserManager<Domain.Entities.Account> userManager)
    {
        _accountService = accountService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<JsonWebToken> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var jwt = await _accountService.SignIn(request.Email, request.Password, cancellationToken);

        return jwt;
    }
}