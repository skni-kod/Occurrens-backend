using FluentValidation;

namespace Occurrens.Application.Account.Command.SignIn;

public class SignInValidator : AbstractValidator<SignInCommand>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!");
    }
}