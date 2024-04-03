using Application.Interfaces;
using Persistence.Contexts;

namespace Persistence.SeedData;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationContext _context;

    public DbInitializer(ApplicationContext context)
    {
        _context = context;
    }

    public void Initialize()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        
        _context.Orders.AddRange(FakeData.Orders);
        _context.SaveChanges();
        _context.Shelves.AddRange(FakeData.Shelves);
        _context.SaveChanges();
        _context.Products.AddRange(FakeData.Products);
        _context.SaveChanges();
        _context.ProductShelves.AddRange(FakeData.ProductShelves);
        _context.SaveChanges();
        _context.OrderProductShelves.AddRange(FakeData.OrderProductShelves);
        _context.SaveChanges();
    }
}