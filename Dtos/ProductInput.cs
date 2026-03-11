using System.ComponentModel.DataAnnotations;
using la_foire_des_prix.Entities;

namespace la_foire_des_prix.Dtos;

public record ProductInput
{
    [Required]
    [StringLength(120)]
    public required string Name { get; init; }

    [StringLength(2048)]
    public string? Description { get; init; }

    [Required]
    [StringLength(60)]
    public required string Category { get; init; }

    [Range(0, 999999)]
    public decimal Price { get; init; }

    [Required]
    [StringLength(3, MinimumLength = 3)]
    public required string Currency { get; init; } = "EUR";

    public bool IsPublished { get; init; }

    [Range(0, 100000)]
    public int StockQuantity { get; init; }

    public Product ToEntity() => new()
    {
        Name = Name.Trim(),
        Description = Description?.Trim(),
        Category = Category.Trim().ToLowerInvariant(),
        Price = decimal.Round(Price, 2, MidpointRounding.ToEven),
        Currency = Currency.Trim().ToUpperInvariant(),
        IsPublished = IsPublished,
        StockQuantity = StockQuantity
    };

    public void ApplyTo(Product product)
    {
        product.Name = Name.Trim();
        product.Description = Description?.Trim();
        product.Category = Category.Trim().ToLowerInvariant();
        product.Price = decimal.Round(Price, 2, MidpointRounding.ToEven);
        product.Currency = Currency.Trim().ToUpperInvariant();
        product.IsPublished = IsPublished;
        product.StockQuantity = StockQuantity;
        product.Touch();
    }
}