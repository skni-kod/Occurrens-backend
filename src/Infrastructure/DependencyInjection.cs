using Domain.Entities;
using FluentValidation;
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


        services.AddHttpContextAccessor();
        //services.AddValidatorsFromAssemblyContaining<SignInCommand>();
            
        return services;
    }
}