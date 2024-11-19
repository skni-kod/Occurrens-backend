using FluentValidation;

namespace Occurrens.Application.DoctorWorkPlace.Queries.GetWorkPlacesForSpecificDoctor;

public class GetWorkPlacesForSpecificDoctorValidator : AbstractValidator<GetWorkPlacesForSpecificDoctorQuery>
{
    public GetWorkPlacesForSpecificDoctorValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotNull().NotEmpty().WithMessage("Wybierz poprawnego lekarza!");
    }
}