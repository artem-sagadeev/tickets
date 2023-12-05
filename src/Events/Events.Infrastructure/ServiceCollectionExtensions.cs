﻿using Events.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            
            return services
                .AddDbContext<ApplicationContext>(builder => builder
                    .UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention())
                .AddScoped<IApplicationContext, ApplicationContext>();
        }
    }
}