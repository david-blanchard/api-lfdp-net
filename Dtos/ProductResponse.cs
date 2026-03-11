using la_foire_des_prix.Entities;

namespace la_foire_des_prix.Dtos;

public record ProductResponse(
    int Id,
    string Name,
    string? Description,
    string Category,
    decimal Price,
    string Currency,
    bool IsPublished,
    int StockQuantity,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt)
{
    public static ProductResponse FromEntity(Product product) => new(
        product.Id,
        product.Name,
        product.Description,
        product.Category,
        product.Price,
        product.Currency,
        product.IsPublished,
        product.StockQuantity,
        product.CreatedAt,
        product.UpdatedAt);
}