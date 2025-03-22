using System.Reflection;
using BankApp.Application.Features.IndividualCustomers.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IndividualCustomerBusinessRules>();

        return services;
    }
} 