using System.Data;
using FluentValidation;

namespace Application.WorkAccount.Commands.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Coś poszło nie tak!");

        RuleFor(x => x.NewPassword)
            .Equal(e => e.ConfirmPassword)
            .WithMessage("Hasła się różnią!");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Niepoprawna rola!");
    }
}