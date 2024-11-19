﻿namespace Occurrens.Domain.Authentication;

public class JwtSettings
{
    public const string SectionName = "Securities";
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int RefreshTokenExpire { get; set; }
}