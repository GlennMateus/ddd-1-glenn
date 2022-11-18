#region

using backend.infra.Context;
using backend.Infra.Repositories.Implementations;
using backend.Infra.Repositories.Interfaces;
using backend.services.Implementations;
using backend.services.Interfaces;
using backend.Services.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace backend;

public class AppServices
{
    private static IServiceCollection _services;
    private static IConfiguration _configuration;

    public AppServices(IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        _configuration = configuration;
    }

    public void Execute()
    {
        ConfigureDbContext();
        ConfigureApiDefaultServices();
        ConfigureServices();
        ConfigureCors();
    }

    private void ConfigureDbContext()
    {
        _services.AddDbContext<Sqlitecontext>(opt =>
        {
            var connectionString = _configuration.GetConnectionString("SQLite");
            opt.UseSqlite(connectionString);
        });
        _services.AddTransient<IPostalCodesRepository, PostalCodesRepository>();
    }

    private void ConfigureCors()
    {
        _services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    private void ConfigureServices()
    {
        _services.AddTransient<ICallPostCodes, CallPostCodes>();
        _services.AddTransient<ICalculateDistanceInKm, CalculateDistanceInKm>();
    }

    private void ConfigureApiDefaultServices()
    {
        _services.Configure<ConnectionStrings>(_configuration.GetRequiredSection("ConnectionStrings"));
        _services.Configure<PostCodeService.Config>(_configuration.GetRequiredSection("PostCodeApi"));
        _services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        _services.AddControllers();
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen();
    }
}