using FluentValidation;

namespace Application.Diseases.Queries;

public class GetPatientDiseasesValidator : AbstractValidator<GetPatientDiseasesQuery>
{
    public GetPatientDiseasesValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().NotNull().WithMessage("Nie wybrano pacjenta!");
    }
}