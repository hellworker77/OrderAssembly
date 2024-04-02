using Domain.DTOs;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    IList<OrderDto> GetOrdersByIds(string idsAsString);
}