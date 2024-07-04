using Application.Account.Enums;

namespace Application.Persistance.Interfaces.Account;

public interface IAccountService
{
    Task<Guid> CreateUserAsync(Domain.Entities.Account user, string password, EnumRole role, CancellationToken cancellationToken);
    Task<Domain.Entities.Account> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<string> GenerateEmailConfirmTokenAsync(Domain.Entities.Account user, CancellationToken cancellationToken);
    Task ConfirmAccountAsync(Guid userId, string token, CancellationToken cancellationToken);
}