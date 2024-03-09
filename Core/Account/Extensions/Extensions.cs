using Core.Account.DTOS;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.Account.Extensions;

public static class Extensions
{
    public static AccountDto DoctorAsDto(this Doctor doctor)
    {
        return new AccountDto
        {
            Id = doctor.Id,
            Pesel = doctor.Pesel,
            Name = doctor.Name,
            Secont_name = doctor.Secont_name,
            Last_name = doctor.Last_name,
            Email = doctor.Email,
            Telephon_number = doctor.Telephon_number,
            Date_of_birth = doctor.Date_of_birth,
            Role = doctor.Role,
            VerificationToken = doctor.VerificationToken,
            VerifiedAt = doctor.VerifiedAt,
            PasswordResetToken = doctor.VerificationToken,
            ResetTokenExpires = doctor.ResetTokenExpires
        };
    }
    
    public static AccountDto PatientAsDto(this Patient patient)
    {
        return new AccountDto
        {
            Id = patient.Id,
            Pesel = patient.Pesel,
            Name = patient.Name,
            Secont_name = patient.Secont_name,
            Last_name = patient.Last_name,
            Email = patient.Email,
            Telephon_number = patient.Telephon_number,
            Date_of_birth = patient.Date_of_birth,
            Role = patient.Role,
            VerificationToken = patient.VerificationToken,
            VerifiedAt = patient.VerifiedAt,
            PasswordResetToken = patient.VerificationToken,
            ResetTokenExpires = patient.ResetTokenExpires
        };
    }
}