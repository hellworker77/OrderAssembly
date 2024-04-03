namespace Domain.DTOs;

public sealed record ProductDto
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    
    public string Name { get; set; }
    public ushort Count { get; set; }
}