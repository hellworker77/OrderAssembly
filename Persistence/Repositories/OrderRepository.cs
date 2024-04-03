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

    public IList<Order> GetOrdersByIds(params int[] ids) =>
        _context.Set<Order>()
            .AsNoTracking()
            .Where(x => ids.Contains(x.Id))
            .Include(order=>order.OrderProductShelves)
            .ThenInclude(orderProductShelves=>orderProductShelves.ProductShelf)
            .ThenInclude(productShelf=>productShelf.Product)
            .Include(order=>order.OrderProductShelves)
            .ThenInclude(orderProductShelves=>orderProductShelves.ProductShelf)
            .ThenInclude(productShelf=>productShelf.Shelf)
            .ToList();
}