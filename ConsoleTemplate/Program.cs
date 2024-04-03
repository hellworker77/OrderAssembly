using Application.Extensions;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Models.Views;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Extensions;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var config = builder.Build();

var services = new ServiceCollection();

services
    .AddInfrastructureLayer()
    .AddApplicationLayer()
    .AddPersistenceLayer(config.GetConnectionString("DbConnection")!);

var provider = services.BuildServiceProvider();

var orderService = provider.GetService<IOrderService>();

var productViews = orderService.GetOrdersByIds(Environment.GetCommandLineArgs()[1]);

PrintProductViews(productViews);

static void PrintProductViews(IList<ProductView> productViews)
{
    var groupedProducts = productViews.GroupBy(p => p.MainShelf);
    foreach (var group in groupedProducts)
    {
        Console.WriteLine($"===Стеллаж {group.Key}");

        foreach (var product in group)
        {
            Console.WriteLine($"{product.Name} (id={product.ProductId})");
            Console.WriteLine($"заказ {product.OrderId}, {product.Count} шт");
            if (!string.IsNullOrEmpty(product.AdditionalShelves))
            {
                Console.WriteLine($"доп стеллаж: {product.AdditionalShelves}");
            }
        }
        Console.WriteLine();
    }
}

Console.ReadLine();