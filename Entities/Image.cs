using System.Collections.Generic;

namespace LaFoireDesPrix.Entities;

public class Image : ITimestampedEntity
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
    public string? Title { get; set; }
    public ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public IReadOnlyDictionary<string, string?> GetData() => new Dictionary<string, string?>
    {
        ["url"] = Url,
        ["alt"] = Alt,
        ["title"] = Title
    };
}
