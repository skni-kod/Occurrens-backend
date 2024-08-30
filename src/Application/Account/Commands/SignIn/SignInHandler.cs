using Application.Account.Authentication;
using Application.Persistance.Interfaces.Account;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Account.Commands.SignIn;

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
        var user = await _accountService.GetUserByEmailAsync(request.Email, cancellationToken);

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
        if (!result.Succeeded) throw new BadRequestException("Wrong data!");

        var userRoles = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var jwtToken = _accountService.GenerateJsonWebToken(user, userRoles, userClaims);

        return jwtToken;
    }
}