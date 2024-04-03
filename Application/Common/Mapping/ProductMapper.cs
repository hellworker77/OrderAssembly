using Domain.DTOs;
using Domain.Entities.LinkedEntity;
using Mapster;

namespace Application.Common.Mapping;

public class ProductMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<ProductShelf, ProductDto>()
            .Map(destination => destination.Name, source => source.Product.Name)
            .Map(destination => destination.ProductId, source => source.ProductId);
    }
}