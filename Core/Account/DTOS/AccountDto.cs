namespace Core.Account.DTOS;

public class AccountDto
{
    public Guid Id { get; set; }
    public long Pesel { get; set; }
    public string Name { get; set; }
    public string? Secont_name { get; set; }
    public string Last_name { get; set; }
    public string Email { get; set; }
    public int Telephon_number { get; set; }
    public DateOnly Date_of_birth { get; set; }
    public string Role { get; set; }
    public string? VerificationToken { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
}