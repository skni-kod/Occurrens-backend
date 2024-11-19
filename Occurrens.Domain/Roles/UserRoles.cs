using Microsoft.AspNetCore.Identity;

namespace Occurrens.Domain.Roles;

public static class UserRoles
{
    public const string Doctor = nameof(Doctor);
    public const string Patient = nameof(Patient);

    private static List<IdentityRole<Guid>> Roles;

    static UserRoles()
    {
        Roles = new List<IdentityRole<Guid>>()
        {
            new(Doctor),
            new(Patient)
        };
    }

    public static List<IdentityRole<Guid>> Get()
    {
        return Roles;
    }
}