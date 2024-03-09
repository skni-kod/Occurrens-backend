using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Core.Account.Repositories;
using Infrastructure.Persistance;
using occurrensBackend.Entities.DatabaseEntities;
using Core.Account.DTOS;
using Core.Account.enums;
using Core.Account.Extensions;
using Core.Date;
using Domain.AuthenticationSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Account.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly OccurrensDbContext _context;
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly IDateService _dateService;
    private readonly IEmailService _emailService;

    public AccountRepository(OccurrensDbContext context, AuthenticationSettings authenticationSettings, IDateService dateService, IEmailService emailService)
    {
        _context = context;
        _authenticationSettings = authenticationSettings;
        _dateService = dateService;
        _emailService = emailService;
    }
    
    public async Task<bool> IsEmailExist(string email, UserRoles role, CancellationToken cancellationToken)
    {
        if (role == UserRoles.Doctor)
        {
            var isExist = await _context.Doctors.AnyAsync(x => x.Email == email, cancellationToken);
            return isExist;
        }
        else if (role == UserRoles.Patient)
        {
            var isExist = await _context.Patients.AnyAsync(x => x.Email == email, cancellationToken);
            return isExist;
        }

        return false;
    }
    
    public async Task<AccountDto> UserData(string email,string password, UserRoles role, CancellationToken cancellationToken)
    {
        if (role == UserRoles.Doctor)
        {
            var doctor =  await _context.Doctors.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (doctor is null) return null;
            
            var passwordVerify = BCrypt.Net.BCrypt.Verify(password, doctor.Password);
            
            if (passwordVerify == false) return null;
            
            return doctor.DoctorAsDto();
        }
        else if (role == UserRoles.Patient)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (patient is null) return null;
            
            var passwordVerification = BCrypt.Net.BCrypt.Verify(password, patient.Password);
            
            if (passwordVerification == false) return null;

            return patient.PatientAsDto();
        }

        return null;
    }

    public async Task<string> GenerateJwt(AccountDto data)
    {
        var claims = new List<Claim>()
        {
          new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
          new Claim(ClaimTypes.Name, $"{data.Name} {data.Last_name}"),
          new Claim(ClaimTypes.Role, $"{data.Role}")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = _dateService.CurrentDateTime().AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(
            _authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred
            );

        var tokenHandler = new JwtSecurityTokenHandler();
         

        return await Task.Run(() => tokenHandler.WriteToken(token));
    }

    public async Task<bool> ConfirmAccount(string token, UserRoles role, Guid id, CancellationToken cancellationToken)
    {
        if (role == UserRoles.Doctor)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null || doctor.VerificationToken != token) return false;

            doctor.VerifiedAt = _dateService.CurrentDateTime();
            await _context.SaveChangesAsync(cancellationToken);
        }
        else if (role == UserRoles.Patient)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is null || patient.VerificationToken != token) return false;

            patient.VerifiedAt = _dateService.CurrentDateTime();
            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
    

    public async Task CreateDoctorAccount(Doctor doctor, CancellationToken cancellationToken)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(doctor.Password);
        
        doctor.Password = hashPassword;
        
        await _context.Doctors.AddAsync(doctor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        
        var emailData = new EmailDto
        {
            To = doctor.Email,
            Subject = "Weryfikacja konta OCCURRENS",
            Body = $"<h1>Potwierdź swoje konto klikając <a href='https://localhost:7192/account/verificateAccount/{doctor.VerificationToken}/{doctor.Role}/{doctor.Id}'>tutaj</a>:</h1>"
        };
        
        await _emailService.SendEmail(emailData);
    }

    public async Task CreatePatientAccount(Patient patient, CancellationToken cancellationToken)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(patient.Password);

        patient.Password = hashPassword;

        await _context.Patients.AddAsync(patient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        var emailData = new EmailDto
        {
            To = patient.Email,
            Subject = "Weryfikacja konta OCCURRENS",
            Body = $"<h1>Potwierdź swoje konto klikając <a href='https://localhost:7192/account/verificateAccount/{patient.VerificationToken}/{patient.Role}/{patient.Id}'>tutaj</a></h1>"
        };
        
        await _emailService.SendEmail(emailData);
    }
    
    public string CreateRandomToken() => Convert.ToHexString(RandomNumberGenerator.GetBytes(256));
    
    public async Task<bool> ForgotPasswordEmail(string email, UserRoles role, CancellationToken cancellationToken)
    {
        if (role == UserRoles.Doctor)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (doctor is null) return false;
            
            var emailData = new EmailDto
            {
                To = email,
                Subject = "Reset hasła OCCURRENS",
                Body = $"<h1>Aby zresetować hasło kliknij<a href='https://localhost:7192/account/generate-token-to-reset-password/{doctor.Id}/{doctor.Role}'>tutaj</a>:</h1>"
            };
            
            await _emailService.SendEmail(emailData);
        }
        else if(role == UserRoles.Patient)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (patient is null) return false;
            
            var emailData = new EmailDto
            {
                To = email,
                Subject = "Reset hasła OCCURRENS",
                Body = $"<h1>Aby zresetować hasło kliknij<a href='https://localhost:7192/account/generate-token-to-reset-password/{patient.Id}/{patient.Role}'>tutaj</a>:</h1>"
            };

            await _emailService.SendEmail(emailData);
        }
        
        return true;
    }

    public async Task<string> GenerateTokenToResterPassword(Guid id, string role, CancellationToken cancellationToken)
    {
        if (role == "Doctor")
        {
            var doctor = await _context.Doctors.FindAsync(id, cancellationToken);

            if (doctor is null) return null;

            doctor.PasswordResetToken = CreateRandomToken();
            doctor.ResetTokenExpires = _dateService.CurrentDateTime().AddMinutes(5);

            await _context.SaveChangesAsync(cancellationToken);

            return doctor.PasswordResetToken;
        }
        else if (role == "Patient")
        {
            var patient = await _context.Patients.FindAsync(id, cancellationToken);

            if (patient is null) return null;

            patient.PasswordResetToken = CreateRandomToken();
            patient.ResetTokenExpires = _dateService.CurrentDateTime().AddMinutes(5);

            await _context.SaveChangesAsync(cancellationToken);

            return patient.PasswordResetToken;
        }

        return null;
    }

    public async Task<bool> ResetPassword(string token, string password, UserRoles role, CancellationToken cancellationToken)
    {
        if (role == UserRoles.Doctor)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.PasswordResetToken == token, cancellationToken);

            if (doctor is null) return false;

            if (doctor.ResetTokenExpires < _dateService.CurrentDateTime()) return false;

            doctor.Password = BCrypt.Net.BCrypt.HashPassword(password);

            doctor.ResetTokenExpires = null;

            await _context.SaveChangesAsync(cancellationToken);
        }
        else if (role == UserRoles.Patient)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.PasswordResetToken == token, cancellationToken);

            if (patient is null) return false;
            
            if (patient.ResetTokenExpires < _dateService.CurrentDateTime()) return false;

            patient.Password = BCrypt.Net.BCrypt.HashPassword(password);

            patient.ResetTokenExpires = null;
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}