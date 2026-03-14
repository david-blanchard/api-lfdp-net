namespace LaFoireDesPrix.Entities;

public class Campaign : ITimestampedEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public int Discount { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
