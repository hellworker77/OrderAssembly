using Domain.DTOs;
using Domain.Models.Views;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    IList<ProductView> GetOrdersByIds(string idsAsString);
}