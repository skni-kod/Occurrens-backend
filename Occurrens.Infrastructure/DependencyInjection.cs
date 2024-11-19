using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Occurrens.Application.Account.Command.SignIn;
using Occurrens.Application.Persistance.Interfaces.Account;
using Occurrens.Application.Persistance.Interfaces.CurrentUser;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;
using Occurrens.Application.Persistance.Interfaces.Email;
using Occurrens.Domain.Entities;
using Occurrens.Infrastructure.Persistance.Accounts.Services;
using Occurrens.Infrastructure.Persistance.CurrentUserService.Services;
using Occurrens.Infrastructure.Persistance.DoctorWorkPlace.Services;
using Occurrens.Infrastructure.Persistance.Email.Config;
using Occurrens.Infrastructure.Persistance.Email.Services;
using Occurrens.Infrastructure.Persistance.Extensions;

namespace Occurrens.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.DatabaseConfiguration(configuration);
        services.AuthorizationSettings(configuration);

        services.AddScoped<SignInManager<Account>>();
        services.AddScoped<UserManager<Account>>();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IDoctorWorkPlaceService, DoctorWorkPlaceService>();

        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequiredLength = 8;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequiredUniqueChars = 6;

            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5);

            opt.User.RequireUniqueEmail = true;
            opt.SignIn.RequireConfirmedEmail = false;
        });

        services.AddHttpContextAccessor();
        services.AddValidatorsFromAssemblyContaining<SignInCommand>();

        var smtpConfig = new SmtpConfig();
        configuration.GetSection("SMTP").Bind(smtpConfig);
        services.AddSingleton(smtpConfig);
        
            
        return services;
    }
}