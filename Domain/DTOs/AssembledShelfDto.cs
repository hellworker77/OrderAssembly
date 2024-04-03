namespace Domain.DTOs;

public sealed record AssembledShelfDto
{
    public string ShelfName { get; set; }
    public bool IsPriority { get; set; }
    public ProductDto Product { get; set; }
}