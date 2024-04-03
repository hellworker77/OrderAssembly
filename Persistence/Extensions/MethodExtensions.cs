using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.SeedData;

namespace Persistence.Extensions;

public static class MethodExtensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection serviceCollection,
        string connectionString) =>
        serviceCollection
            .AddDbContext(connectionString)
            .AddRepositories()
            .AddDbInitializer();
    private static IServiceCollection AddDbContext(this IServiceCollection serviceCollection,
        string connectionString) =>
        serviceCollection.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(connectionString,
                migration => migration.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            options.UseLazyLoadingProxies();

        });
    private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection) =>
        serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
    private static IServiceCollection AddDbInitializer(this IServiceCollection services) => 
        services.AddTransient<IDbInitializer, DbInitializer>();
}