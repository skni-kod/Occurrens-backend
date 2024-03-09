using System.Data;
using FluentValidation;

namespace Application.WorkAccount.Commands.RegisterUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Password)
            .Equal(e => e.ConfirmPassword).WithMessage("Hasła nie są równe!");

        RuleFor(x => x.Pesel)
            .NotEmpty().WithMessage("Podaj PESEL!")
            .Must(x => long.TryParse(x.ToString(), out _))
            .WithMessage("Podaj poprawny PESEL");

        RuleFor(x => x.TelNumber)
            .NotEmpty().WithMessage("Podaj numer telefonu!")
            .Must(x => long.TryParse(x.ToString(), out _))
            .WithMessage("Podaj poprawny numer telefonu");

        RuleFor(x => x.Acception)
            .NotEmpty()
            .Equal(true).WithMessage("Zaakceptowanie przetwarzania danych jest wymagane!");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Wybierz opcję rejestracji!")
            .IsInEnum().WithMessage("Niepoprawna rola!");
    }
}