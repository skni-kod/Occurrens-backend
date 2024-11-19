using FluentValidation;

namespace Occurrens.Application.DoctorWorkPlace.Commands.UpdateDoctorWorkPlace;

public class UpdateDoctorWorkPlaceValidator : AbstractValidator<UpdateDoctorWorkPlaceCommand>
{
    public UpdateDoctorWorkPlaceValidator()
    {
        RuleFor(x => x.WorkPlaceId)
            .NotNull().NotEmpty().WithMessage("Nie wybrano miejsca do edycji!");
        
        RuleFor(x => x.Street)
            .NotEmpty().NotNull().WithMessage("Pole ulicy jest wymagane!");

        RuleFor(x => x.BuildingNumber)
            .NotNull().WithMessage("Pole numeru domu jest wymagane");

        RuleFor(x => x.PostalCode)
            .NotNull().NotEmpty().WithMessage("Pole kodu pocztowego jest wymagane!")
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Niepoprawny format kodu pocztowego. Wprowadź kod w formacie XX-XXX.");

        RuleFor(x => x.City)
            .NotNull().NotEmpty().WithMessage("Pole miasta jest wymagane!"); 
    }
}