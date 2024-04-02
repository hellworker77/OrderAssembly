using Domain.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Common.Mapping;

public class OrderMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Order, OrderDto>();
    }
}
