using Domain.Entities.Abstract;

namespace Domain.Entities.LinkedEntity;

public class ProductShelf : BaseEntity
{
    public virtual Product Product { get; set; }
    public int ProductId { get; set; }
    public virtual Shelf Shelf { get; set; }
    public int ShelfId { get; set; }

    public bool IsPriority { get; set; }
    public virtual IList<OrderProductShelf> OrderProductShelves { get; set;  } 
}