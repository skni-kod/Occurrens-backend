using FluentValidation;

namespace Application.Diseases.Commands.AddDisease;

public class AddDiseaseValidator : AbstractValidator<AddDiseaseCommand>
{
    public AddDiseaseValidator()
    {
        RuleFor(x => x.PatientId)
            .NotNull().NotEmpty().WithMessage("Musisz podać pacjenta");

        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("Musisz podać nazwę choroby");

        RuleFor(x => x.Description)
            .NotEmpty().NotNull().WithMessage("Musisz dodać opis choroby");

        RuleFor(x => x.Medicines)
            .NotEmpty().NotNull().WithMessage("Musisz podać sposób leczenia"); 
    }
}