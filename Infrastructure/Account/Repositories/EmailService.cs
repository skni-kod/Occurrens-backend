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
        email.From.Add(MailboxAddress.Parse("occurrens@wp.pl"));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) {Text = request.Body};
        
        using var smtp = new SmtpClient();
        
        await smtp.ConnectAsync("smtp.wp.pl", 465, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync("occurrens@wp.pl", "8!HP?S6fW)nuZj2");
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true); 
    } 
}