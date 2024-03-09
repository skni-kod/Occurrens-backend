using System.Text;
using Core.Account.Repositories;
using Core.DataFromClaims.UserId;
using Core.Date;
using Core.Diseases.Repositories;
using Core.DoctorInformations.Repositories;
using Domain.AuthenticationSettings;
using Infrastructure.Account.Repositories;
using Infrastructure.DataFromClaims.UserId;
using Infrastructure.Date;
using Infrastructure.Diseases.Repositories;
using Infrastructure.DoctorInformations.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OccurrensDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"),
                r => r.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));

        
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IDateService, DateService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IDoctorInfoRepository, DoctorInfoRepository>();
        services.AddScoped<IGetUserId, GetUserId>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();
        
        services.AddHttpContextAccessor(); 
        
        return services;
    }

    public static IServiceCollection AddAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        var authenticationSettings = new AuthenticationSettings();
        configuration.GetSection("Authentication").Bind(authenticationSettings);
        services.AddSingleton(authenticationSettings);

        services.AddAuthentication(options =>
        { 
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
            };
        });
        
        return services;
    }
}