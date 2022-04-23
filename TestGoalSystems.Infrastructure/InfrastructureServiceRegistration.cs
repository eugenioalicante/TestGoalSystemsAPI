using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Infrastructure.Persistence;
using TestGoalSystems.Infrastructure.Repositories;

namespace TestGoalSystems.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IInventoryRepository, InventoryRepository>();            

            return services;
        }
    }
}
