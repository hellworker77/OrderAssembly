using Application.Interfaces;
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
    .AddPersistenceLayer(config.GetConnectionString("DbConnection")!);

var provider = services.BuildServiceProvider();

var dbInitializer = provider.GetService<IDbInitializer>();

dbInitializer.Initialize();



