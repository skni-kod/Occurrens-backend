using Core.Account.DTOS;
using Core.Account.enums;
using occurrensBackend.Entities.DatabaseEntities;

namespace Core.Account.Repositories;

public interface IAccountRepository
{
    Task CreateDoctorAccount(Doctor doctor, CancellationToken cancellationToken);
    Task CreatePatientAccount(Patient patient, CancellationToken cancellationToken);
    Task<bool> IsEmailExist(string email, UserRoles role, CancellationToken cancellationToken);
    Task<AccountDto> UserData(string email,string password,UserRoles role, CancellationToken cancellationToken);
    Task<string> GenerateJwt(AccountDto data); 
    Task<bool> ConfirmAccount(string token, UserRoles role, Guid id, CancellationToken cancellationToken);
    string CreateRandomToken();
    Task<bool> ForgotPasswordEmail(string email, UserRoles role, CancellationToken cancellationToken);
    Task<string> GenerateTokenToResterPassword(Guid id, string role, CancellationToken cancellationToken);
    Task<bool> ResetPassword(string token, string password, UserRoles role, CancellationToken cancellationToken);
}