using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Commands.SignInUser;

public record SignInUserCommand(
    string Login,
    string Password, 
    UserRoles Who
    ) : IRequest<ErrorOr<AccountResponse>>;