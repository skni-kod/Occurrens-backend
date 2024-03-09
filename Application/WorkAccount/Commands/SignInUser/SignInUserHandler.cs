using Application.Common.Errors;
using Application.Contracts.AccountAnswer;
using Core.Account.Repositories;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Commands.SignInUser;

public class SignInUserHandler : IRequestHandler<SignInUserCommand, ErrorOr<AccountResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public SignInUserHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
        
    public async Task<ErrorOr<AccountResponse>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _accountRepository.UserData(request.Login,request.Password ,request.Who, cancellationToken);

        if (user is null) return Errors.UserErrors.NullEmailOrPasswork;

        if (user.VerifiedAt == null) return Errors.UserErrors.AccountNotVerified;

        var token = await _accountRepository.GenerateJwt(user);

        return new AccountResponse(token);
    }
}