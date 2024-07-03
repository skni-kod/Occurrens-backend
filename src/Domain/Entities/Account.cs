using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;

public class Account : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string? SecondName { get; set; }
    public string Surname { get; set; }
    public string Pesel { get; set; }
    public DateOnly BirthDate { get; set; }
}

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        
    }
}