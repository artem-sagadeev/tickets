using Microsoft.Extensions.DependencyInjection;
using Organizations.Application.Interfaces;
using Organizations.Application.Services;

namespace Organizations.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddScoped<IOrganizationService, OrganizationService>();
    }
}