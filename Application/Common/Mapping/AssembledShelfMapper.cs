using Domain.DTOs;
using Domain.Entities.LinkedEntity;
using Mapster;

namespace Application.Common.Mapping;

public class AssembledShelfMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<OrderProductShelf, AssembledShelfDto>()
            .Map(destination => destination.ShelfName,
                source => source.Product.Shelf.Name)
            .Map(destination => destination.Product.Count, source => source.Count)
            .Map(destination => destination.Product.OrderId, source => source.OrderId)
            .Map(destination => destination.Product, source => source.Product);

    }
}