using BankApp.Core.Repositories;
using BankApp.Persistence.Contexts;
using BankApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("BankApp")));

        services.AddScoped(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));

        return services;
    }
} 