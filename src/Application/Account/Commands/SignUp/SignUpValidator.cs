using FluentValidation;

namespace Application.Account.Commands.SignUp;

public class SignUpValidator : AbstractValidator<SignUpCommand>
{
    public SignUpValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required!");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telephon number is required!");

        RuleFor(x => x.Pesel)
            .NotEmpty().WithMessage("Pesel is required!");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Dirth date is required!");

        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress().WithMessage("Email is required!");

        RuleFor(x => x.RepeatPassword)
            .Equal(x => x.Password).WithMessage("Password not equal!");
    }
}