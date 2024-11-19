using FluentValidation;

namespace Occurrens.Application.DoctorWorkPlace.Commands.DeleteDoctorWorkPlace;

public class DeleteDoctorWorkPlaceValidator : AbstractValidator<DeleteDoctorWorkPlaceCommand>
{
    public DeleteDoctorWorkPlaceValidator()
    {
        RuleFor(x => x.DoctorPlaceId)
            .NotEmpty().NotNull().WithMessage("Wybierz poprawne miejsce do usunięcia!");
    }
}