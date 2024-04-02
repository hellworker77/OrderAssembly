using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IOrderRepository
{
    IList<Order> GetOrdersByIds(params int[] ids);
}