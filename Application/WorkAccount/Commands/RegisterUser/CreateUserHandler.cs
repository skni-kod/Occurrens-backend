using System.Security.Cryptography;
using Application.Common.Errors;
using Application.Contracts.AccountAnswer;
using Core.Account.enums;
using Core.Account.Repositories;
using ErrorOr;
using MediatR;
using occurrensBackend.Entities.DatabaseEntities;

namespace Application.WorkAccount.Commands.RegisterUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<AccountResponse>>
{
    private readonly IAccountRepository _accountRepository;
    
    public CreateUserHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }   
    
    public async Task<ErrorOr<AccountResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExist = await _accountRepository.IsEmailExist(request.Email, request.Role, cancellationToken);

        if (isEmailExist)
        {
            return Errors.UserErrors.DuplicateEmail;
        }

        var user = CreateUserFromRequest(request);

        if (user is Doctor doctor)
        {
            await _accountRepository.CreateDoctorAccount(doctor, cancellationToken);
        }
        else if (user is Patient patient)
        {
            await _accountRepository.CreatePatientAccount(patient, cancellationToken);
        }
        
        return new AccountResponse("Pomyślnie utworzono konto!");
    }

    private dynamic CreateUserFromRequest(CreateUserCommand request)
    {
        return request.Role switch
        {
            UserRoles.Doctor => new Doctor
            {
                Pesel = request.Pesel,
                Name = request.Name,
                Secont_name = request.SecontName,
                Last_name = request.LastName,
                Telephon_number = request.TelNumber,
                Email = request.Email,
                Password = request.Password,
                Date_of_birth = request.BirthDate,
                Role = request.Role.ToString(),
                Acception = request.Acception,
                VerificationToken = _accountRepository.CreateRandomToken()
            },
            UserRoles.Patient => new Patient
            {
                Pesel = request.Pesel,
                Name = request.Name,
                Secont_name = request.SecontName,
                Last_name = request.LastName,
                Telephon_number = request.TelNumber,
                Email = request.Email,
                Password = request.Password,
                Date_of_birth = request.BirthDate,
                Role = request.Role.ToString(),
                Acception = request.Acception,
                VerificationToken = _accountRepository.CreateRandomToken()
            },
        };
    }
    
}