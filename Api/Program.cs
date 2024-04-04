using Application;
using Infrastructure;
using Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo{ Title = "Api", Version = "v1"});
    
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Podaj token JWT {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {   
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddCors(opt => 
{
    opt.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
}); 


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation()
    .AddCore()
    .AddAuthorization(builder.Configuration);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.ApplyPendingMigrations();

app.MapControllers();

app.Run();
