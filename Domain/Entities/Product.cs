using Domain.Entities.Abstract;
using Domain.Entities.LinkedEntity;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } 
    public virtual IList<ProductShelf> ProductShelves { get; set; }
}