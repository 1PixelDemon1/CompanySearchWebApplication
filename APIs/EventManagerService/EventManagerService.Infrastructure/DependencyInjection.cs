using EventManagerService.Application.Interfaces;
using EventManagerService.Infrastructure.Data;
using EventManagerService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventManagerService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EventManagerDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // Fixes tiny bug with DateTime Postgres values.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
