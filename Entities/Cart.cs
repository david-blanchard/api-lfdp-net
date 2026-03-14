namespace LaFoireDesPrix.Entities;

public class Cart : ITimestampedEntity
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public int Count { get; set; }
    public User? Client { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
