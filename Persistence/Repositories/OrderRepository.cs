using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Entities.LinkedEntity;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IList<Order> GetOrdersByIds(params int[] ids) 
    {
        var orders = _context.Set<Order>()
            .Where(x => ids.Contains(x.Id))
            .ToList();
        
        var orderIds = orders.Select(order => order.Id).ToList();
        var orderProductShelves = _context.Set<OrderProductShelf>()
            .Where(orderProductShelf => orderIds.Contains(orderProductShelf.OrderId))
            .ToList();

        var productShelfIds = orderProductShelves.Select(x => x.ProductId).ToList();
        
        var productShelves = _context.Set<ProductShelf>()
            .Where(productShelf => productShelfIds.Contains(productShelf.Id))
            .ToList();

        var shelfIds = productShelves.Select(x => x.ShelfId).ToList();

        var shelves = _context.Set<Shelf>()
            .Where(shelf => shelfIds.Contains(shelf.Id))
            .ToList();

        var productIds = productShelves.Select(x => x.ProductId).ToList();

        var products = _context.Set<Product>()
            .Where(product => productIds.Contains(product.Id))
            .ToList();
        
        
        foreach (var order in orders)
        {
            order.OrderProductShelves = orderProductShelves
                .Where(orderProductShelf => orderProductShelf.OrderId == order.Id)
                .Select(orderProductShelf => new OrderProductShelf()
                {
                    OrderId = orderProductShelf.Id,
                    Count = orderProductShelf.Count,
                    ProductShelf = productShelves
                        .Where(x=>x.Id == orderProductShelf.ProductId)
                        .Select(productShelf => new ProductShelf()
                        {
                            ProductId = productShelf.ProductId,
                            ShelfId = productShelf.ShelfId,
                            Shelf = shelves.First(x=>x.Id == productShelf.ShelfId),
                            Product = products.First(x=>x.Id == productShelf.ProductId),
                            IsPriority = productShelf.IsPriority
                        })
                        .First()
                })
                .ToList();
        }

        return orders;
        
    }
}