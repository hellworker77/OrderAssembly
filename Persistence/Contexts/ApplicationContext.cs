using System.Reflection;
using Domain.Entities;
using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> optionsBuilder) : base(optionsBuilder)
    {
        
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Shelf> Shelves => Set<Shelf>();
    public DbSet<OrderProductShelf> OrderProductShelves => Set<OrderProductShelf>();
    public DbSet<ProductShelf> ProductShelves => Set<ProductShelf>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}