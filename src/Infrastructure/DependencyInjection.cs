﻿using Application.Persistance.Interfaces.Account;
using Domain.Entities;
using Infrastructure.Persistance.Accounts.Services;
using Infrastructure.Persistance.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.DatabaseConfiguration(configuration);

        services.AddScoped<SignInManager<Account>>();
        services.AddScoped<UserManager<Account>>();

        services.AddScoped<IAccountService, AccountService>();

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
        //services.AddValidatorsFromAssemblyContaining<SignInCommand>();
            
        return services;
    }
}