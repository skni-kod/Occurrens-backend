using Application.Common.Errors;
using Application.Contracts.AccountAnswer;
using Core.Account.Repositories;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Queries.GenerateTokenToResetPassword;

public class GenerateTokenToResetPasswordHandler : IRequestHandler<GenerateTokenToResetPasswordCommand, ErrorOr<AccountResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public GenerateTokenToResetPasswordHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository; 
    }
    
    public async Task<ErrorOr<AccountResponse>> Handle(GenerateTokenToResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountRepository.GenerateTokenToResterPassword(request.Id, request.Role, cancellationToken);

        if (result == null) return Errors.UserErrors.SomethinkWentWrong;

        return new AccountResponse(result); 
    }
}