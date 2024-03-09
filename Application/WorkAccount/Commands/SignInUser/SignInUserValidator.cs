using FluentValidation;

namespace Application.WorkAccount.Commands.SignInUser;

public class SignInUserValidator : AbstractValidator<SignInUserCommand>
{
    public SignInUserValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Podaj poprawny e-mail!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Podaj poprawne hasło!");

        RuleFor(x => x.Who)
            .NotEmpty().WithMessage("Nie wybrano roli!")
            .IsInEnum().WithMessage("Niepoprawna opcja logowania!!");
    }
}