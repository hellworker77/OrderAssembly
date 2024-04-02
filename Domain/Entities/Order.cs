using Domain.Entities.Abstract;
using Domain.Entities.LinkedEntity;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public virtual IList<OrderProductShelf> ProductShelves { get; set; }
    public virtual OrderProductShelf OrderProductShelf { get; set; }
}