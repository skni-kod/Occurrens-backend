using FluentValidation;

namespace Application.Diseases.Commands.DeleteDisease;

public class DeleteDiseaseValidator : AbstractValidator<DeleteDiseaseCommand>
{
    public DeleteDiseaseValidator()
    {
        RuleFor(x => x.DiseaseId)
            .NotEmpty().NotNull().WithMessage("Wybierz opis medyczny!");
    }
}