using Core.Account.DTOS;
using Core.Account.Repositories;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Infrastructure.Account.Repositories;

public class EmailService : IEmailService
{
    public async Task SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("project_occurrens@proton.me"));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) {Text = request.Body};
        
        using var smtp = new SmtpClient();
        
        await smtp.ConnectAsync("smtp-relay.brevo.com ", 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync("projektoccurrens@gmail.com", "ER2DSjU1yBxLTMY6 ");
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true); 
    } 
}