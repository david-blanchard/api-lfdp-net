namespace LaFoireDesPrix.Entities;

public class Brand : ITimestampedEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
