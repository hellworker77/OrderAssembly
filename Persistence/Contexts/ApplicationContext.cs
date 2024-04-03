using System.Reflection;
using Domain.Entities;
using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> optionsBuilder) : base(optionsBuilder)
    {
        
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Shelf> Shelves => Set<Shelf>();
    public DbSet<OrderProductShelf> OrderProductShelves => Set<OrderProductShelf>();
    public DbSet<ProductShelf> ProductShelves => Set<ProductShelf>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5433;Database=AssemblyOrder_dev;User Id=postgres;Password=zxc;Integrated Security=true;Command Timeout=20;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}