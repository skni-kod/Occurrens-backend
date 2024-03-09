namespace Domain.AuthenticationSettings;

public class AuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireDays { get; set; }
    public string JwtIssuer { get; set; } 
    public char[] JwtKet { get; set; }
}