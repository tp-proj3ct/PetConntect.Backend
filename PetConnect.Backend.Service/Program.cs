using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;


namespace MNX.MonitoringCenter.Management;
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

        var services = builder.Services;
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        services.AddHealthChecks();
        services.AddSwaggerGen(options =>
        {
            //var basePath = AppContext.BaseDirectory;
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(basePath, xmlFile);
            //options.IncludeXmlComments(xmlPath);
        });

        ConfigureDI(services, builder.Configuration);

        return builder;
    }
    private static void ConfigureDI(IServiceCollection services, ConfigurationManager configuration)
    {
        // DB Context
        var connectionStrings = configuration.GetConnectionString("DefaultConnection");
        //services.AddDbContext<Context>(options =>
        //{
        //    options.UseNpgsql(connectionStrings);
        //});
        // MediatR
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPostCommand).Assembly));
        // Dependencies
        
    }

    private static async Task RunApp(WebApplicationBuilder builder)
    {
        var app = builder.Build();
        var appName = builder.Configuration["ServiceName"]?? throw new ArgumentNullException("ServiceName", "?? ??????? ???????? ???????");

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

        app.UseAuthorization();

        app.MapControllers();
        app.MapHealthChecks("/health");
        app.MapGet(string.Empty, async ctx => await ctx.Response.WriteAsync(appName));

        await app.RunAsync();
    }
}