using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.DTOs;
using Domain.Models.Views;
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


    public IList<ProductView> GetOrdersByIds(string idsAsString)
    {
        var ids = idsAsString
            .Split(',')
            .Select(x => int.Parse(x))
            .ToArray();
        
        var orders = _orderRepository.GetOrdersByIds(ids);

        var nestedCollection = _mapper.Map<IList<OrderDto>>(orders);

        var assembledShelfDtos = new List<AssembledShelfDto>();
        
        var productViews = new List<ProductView>();
        
        foreach (var orderDto in nestedCollection)
        {
            assembledShelfDtos.AddRange(orderDto.OrderedByShelfProducts);
        }

        var uniqueCortegeOfIds = GetAllUniqueProductIdsInOrderFromAssembledShelfDtos(assembledShelfDtos);

        foreach (var uniqueCortegeOfId in uniqueCortegeOfIds)
        {
            var productView = GetProductViewFromAssembledShelfDtos(assembledShelfDtos
                .Where(x => x.Product.ProductId == uniqueCortegeOfId.Id &&
                            x.Product.OrderId == uniqueCortegeOfId.OrderId)
                .ToList());
            productViews.Add(productView);
        }
        
        return productViews;
    }

    private ProductView GetProductViewFromAssembledShelfDtos(IList<AssembledShelfDto> assembledShelfDtos)
    {
        return new ProductView
        {
            MainShelf = assembledShelfDtos.First(x => x.IsPriority).ShelfName,
            ProductId = assembledShelfDtos.First().Product.ProductId,
            OrderId = assembledShelfDtos.First().Product.OrderId,
            Name = assembledShelfDtos.First().Product.Name,
            Count = assembledShelfDtos.First(x => x.IsPriority).Product.Count,
            AdditionalShelves = string.Join(",",assembledShelfDtos.Where(x=>!x.IsPriority).Select(x=>x.ShelfName))
        };
    }

    private IList<(int Id, int OrderId)> GetAllUniqueProductIdsInOrderFromAssembledShelfDtos(IList<AssembledShelfDto> assembledShelfDtos)
    {
        var uniqueProductIds = new List<(int Id, int OrderId)>();

        foreach (var assembledShelfDto in assembledShelfDtos)
        {
            if (!uniqueProductIds.Any(x=>x.Id == assembledShelfDto.Product.ProductId && x.OrderId == assembledShelfDto.Product.OrderId))
            {
                uniqueProductIds.Add((assembledShelfDto.Product.ProductId,assembledShelfDto.Product.OrderId));
            }
        }

        return uniqueProductIds;
    }
}