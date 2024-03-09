using FluentValidation;

namespace Application.WorkAccount.Queries.ForgotPassword;

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordQuery>
{
    public ForgotPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Podaj poprawny e-mail");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Wybierz czy jesteś lekarzem, czy pacjentem")
            .IsInEnum().WithMessage("Wybierz pacjelnta lub doktora!"); 
    }
}