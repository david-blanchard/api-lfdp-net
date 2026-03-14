using System.Collections.ObjectModel;

namespace LaFoireDesPrix.Entities;

public class Product : ITimestampedEntity, IProductEntity
{
    private readonly Collection<ProductImage> _productImages = new();

    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? MoreInfo { get; set; }
    public string Category { get; set; } = "general";
    public decimal Price { get; set; }
    public string Currency { get; set; } = "EUR";
    public bool IsPublished { get; set; }
    public int StockQuantity { get; set; }
    public Brand? Brand { get; set; }
    public IReadOnlyCollection<ProductImage> ProductImages => _productImages;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public void Touch()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    public string GetCategoryName() => Category;

    public void AddProductImage(ProductImage image)
    {
        if (!_productImages.Contains(image))
        {
            _productImages.Add(image);
            image.Product = this;
        }
    }

    public void RemoveProductImage(ProductImage image)
    {
        if (_productImages.Remove(image) && image.Product == this)
        {
            image.Product = null;
        }
    }
}