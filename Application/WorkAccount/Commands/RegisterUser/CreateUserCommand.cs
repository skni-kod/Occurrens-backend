using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using MediatR;
using ErrorOr;

namespace Application.WorkAccount.Commands.RegisterUser;

public record CreateUserCommand(
    long Pesel,
    string Name,
    string? SecontName,
    string LastName,
    int TelNumber,
    string Email,
    string Password,
    string ConfirmPassword, 
    DateOnly BirthDate,
    UserRoles Role,
    bool Acception
    ) : IRequest<ErrorOr<AccountResponse>>;