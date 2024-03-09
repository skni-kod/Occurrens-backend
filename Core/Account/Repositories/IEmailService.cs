using Core.Account.DTOS;

namespace Core.Account.Repositories;

public interface IEmailService
{
    Task SendEmail(EmailDto request);
}