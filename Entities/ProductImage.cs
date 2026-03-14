namespace LaFoireDesPrix.Entities;

public class ProductImage : ITimestampedEntity
{
    public int Id { get; set; }
    public Image? Image { get; set; }
    public Product? Product { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
