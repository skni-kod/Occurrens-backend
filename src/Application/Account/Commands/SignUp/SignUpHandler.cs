using Application.Account.Responses;
using Application.Persistance.Interfaces.Account;
using MediatR;


namespace Application.Account.Commands.SignUp;

public sealed class SignUpHandler : IRequestHandler<SignUpCommand, SignUpResponse>
{
    private readonly IAccountService _accountService;

    public SignUpHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    public async Task<SignUpResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.Account
        {
            Name = request.Name,
            UserName = request.Email,
            SecondName = request.SecondName,
            Surname = request.Surname,
            Pesel = request.Pesel,
            PhoneNumber = request.PhoneNumber,
            BirthDate = request.BirthDate,
            Email = request.Email
        };

        var userId = await _accountService.CreateUserAsync(user, request.Password, request.Role, cancellationToken);

        return new SignUpResponse("Success!");
    }
}