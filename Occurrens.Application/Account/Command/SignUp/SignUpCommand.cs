using MediatR;
using Occurrens.Application.Account.Enums;
using Occurrens.Application.Account.Responses;

namespace Occurrens.Application.Account.Command.SignUp;

public sealed record SignUpCommand(
    string Name,
    string SecondName,
    string Surname,
    string Pesel,
    string PhoneNumber,
    DateOnly BirthDate,
    string Email,
    string Password,
    string RepeatPassword,
    EnumRole Role
) : IRequest<SignUpResponse>;