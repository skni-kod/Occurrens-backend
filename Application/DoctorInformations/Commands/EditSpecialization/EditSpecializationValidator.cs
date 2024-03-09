using FluentValidation;

namespace Application.DoctorInformations.Commands.EditSpecialization;

public class EditSpecializationValidator : AbstractValidator<EditSpecializationCommand>
{
    public EditSpecializationValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("Nie wybrano specjalizacji do edycji!");

        RuleFor(x => x.NewSpecialization)
            .NotNull().NotEmpty().WithMessage("Nie podałeś nowej specjalizacji!"); 
    }
}