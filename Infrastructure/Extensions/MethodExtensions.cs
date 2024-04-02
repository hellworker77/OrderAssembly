using Application.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class MethodExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceCollection) =>
        serviceCollection.AddServices();

    private static IServiceCollection AddServices(this IServiceCollection serviceCollection) =>
        serviceCollection.AddTransient<IOrderService, OrderService>();
}