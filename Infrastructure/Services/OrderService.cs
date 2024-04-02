using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.DTOs;
using MapsterMapper;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }


    public IList<OrderDto> GetOrdersByIds(string idsAsString)
    {
        var ids = idsAsString
            .Split(',')
            .Select(x => int.Parse(x))
            .ToArray();
        
        var orders = _orderRepository.GetOrdersByIds(ids);

        var result = _mapper.Map<IList<OrderDto>>(orders);

        return result;
    }
}