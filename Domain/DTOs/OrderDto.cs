namespace Domain.DTOs;

public sealed record OrderDto
{
    public IList<AssembledShelfDto> OrderedByShelfProducts { get; set; } 
}