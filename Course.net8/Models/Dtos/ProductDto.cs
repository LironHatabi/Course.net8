namespace Course.net8.Models.Dtos;

public record ProductDto
{
    public required int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
}