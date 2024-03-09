using FluentValidation;

namespace Application.DoctorInformations.Commands.SetSpecialization;

public class SetSpecializationValidator : AbstractValidator<SetSpecializationCommand>
{
    public SetSpecializationValidator()
    {
        RuleFor(x => x.Specialization)
            .NotEmpty().WithMessage("Nie możesz dodać pustej specjalizacji!");
    }
}