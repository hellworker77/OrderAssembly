using Domain.Entities.Abstract;

namespace Domain.Entities.LinkedEntity;

public class OrderProductShelf : BaseEntity
{
    public virtual Order Order { get; set; }
    public int OrderId { get; set; }
    
    public virtual ProductShelf ProductShelf { get; set; }
    public virtual int ProductId { get; set; }
    
    public ushort Count { get; set; }
}