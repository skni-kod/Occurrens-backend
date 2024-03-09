using FluentValidation;

namespace Application.Diseases.Commands.UpdateDisease;

public class UpdateDiseaseValidator : AbstractValidator<UpdateDiseaseCommand>
{
    public UpdateDiseaseValidator()
    {
        RuleFor(x => x.DiseaseId)
            .NotEmpty().NotEmpty().WithMessage("Wybierz co chcesz edytować");
    }
}