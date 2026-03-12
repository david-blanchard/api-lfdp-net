namespace LaFoireDesPrix.Entities;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; } = "general";
    public decimal Price { get; set; }
    public string Currency { get; set; } = "EUR";
    public bool IsPublished { get; set; }
    public int StockQuantity { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public void Touch()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}