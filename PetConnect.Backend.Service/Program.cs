    using PetConnect.Backend.DataAccess;
using PetConnect.Backend.DataAccess.Repositories;
using PetConnect.Backend.UseCases.Abstractions;
using PetConnect.Backend.UseCases.Queries.Users.GetAllUsersQuery;
using PetConnect.Backend.UseCases.Commands.Auth.RegistrationCommand;

using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.IdentityModel.Tokens;
using PetConnect.Backend.Infrastructure;
using PetConnect.Backend.Core.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;
using PetConnect.Backend.Service.SwaggerFilters;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.ComponentModel.DataAnnotations;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.Service;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = ConfigureApp(args);
        await RunApp(builder);
    }

    private static WebApplicationBuilder ConfigureApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
            
        var services = builder.Services;
        var cfg = builder.Configuration;

        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        AddAuthentication(builder.Services, builder.Configuration);
        AddAuthorization(builder.Services, builder.Configuration);

        services.AddHealthChecks();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
            options.OperationFilter<AuthorizeCheckOperationFilter>();

            var basePath = AppContext.BaseDirectory;
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(basePath, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });


        ConfigureDI(services, cfg);
         
        return builder;
    }
    
    private static void ConfigureDI(IServiceCollection services, ConfigurationManager configuration)
    {
        // DB Context
        var connectionStrings = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<Context>(options =>
        {
            options.UseNpgsql(connectionStrings);
        });
        // FluentValidation
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<RegistrationCommandValidator>();
        // MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly));
        // Dependencies
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<UserAccessor>();
        // Options
        services.Configure<PetConnect.Backend.Core.Options.PasswordOptions>(configuration.GetSection("PasswordOptions"));
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

    }

    private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfig["Jwt:Issuer"],
                ValidAudience = jwtConfig["Jwt:Audience"],
                IssuerSigningKey = key
            };
        });

        services.AddHttpContextAccessor();
    }
    
    private static void AddAuthorization(IServiceCollection services, IConfiguration _)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy("AdminPolicy", policy =>
            {
                policy.RequireRole("Admin");
            })
            .AddPolicy("PetSitterPolicy", policy =>
            {
                policy.RequireRole("PetSitter");
            })  
            .AddPolicy("PetOwnerPolicy", policy =>
            {
                policy.RequireRole("PetOwner");
            });

        services.AddScoped<ITokenService, TokenService>();
    }

    private static async Task RunApp(WebApplicationBuilder builder)
    {
        var app = builder.Build();
        var appName = builder.Configuration["ServiceName"]?? throw new ArgumentNullException("ServiceName", "ServiceName is not provided");

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseRouting();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHealthChecks("/health");
        app.MapGet(string.Empty, async ctx => await ctx.Response.WriteAsync(appName));

        app.MapControllers();

        await app.RunAsync();
    }
}