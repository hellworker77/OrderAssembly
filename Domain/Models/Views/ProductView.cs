using System.Text;

namespace Domain.Models.Views;

public class ProductView
{
    public string MainShelf { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    
    public string Name { get; set; }
    public ushort Count { get; set; }
    public string AdditionalShelves { get; set; } = string.Empty;
}