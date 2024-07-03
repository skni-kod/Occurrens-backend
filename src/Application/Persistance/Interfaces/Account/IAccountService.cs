using Application.Account.Enums;

namespace Application.Persistance.Interfaces.Account;

public interface IAccountService
{
    Task<Guid> CreateUserAsync(Domain.Entities.Account user, string password, EnumRole role, CancellationToken cancellationToken);
}