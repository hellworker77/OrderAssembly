using Domain.Entities.LinkedEntity;

namespace Domain.Entities;

public class Product
{
    public string Name { get; set; } 
    public virtual IList<ProductShelf> ProductShelves { get; set; }
}