using FluentValidation;

namespace Application.Appointment.Patients.Commands.AppointmentToDoctor;

public class AppointmentToDoctorValidator : AbstractValidator<AppointmentToDoctorCommand>
{
    public AppointmentToDoctorValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().NotNull().WithMessage("Nie wybrano lekarza!");

        RuleFor(x => x.Description)
            .NotEmpty().NotNull().WithMessage("Dodaj opis!");
    }
}