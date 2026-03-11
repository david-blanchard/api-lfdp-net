using la_foire_des_prix.Entities;

namespace la_foire_des_prix.Filters;

public class ProductFilter : IResourceFilter<Product>
{
    public string? Search { get; set; }
    public string? Category { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? IsPublished { get; set; }
    public string? Currency { get; set; }

    public IQueryable<Product> Apply(IQueryable<Product> query)
    {
        if (!string.IsNullOrWhiteSpace(Search))
        {
            var lowered = Search.Trim().ToLowerInvariant();
            query = query.Where(p => p.Name.ToLower().Contains(lowered) ||
                                     (p.Description != null && p.Description.ToLower().Contains(lowered)));
        }

        if (!string.IsNullOrWhiteSpace(Category))
        {
            var normalized = Category.Trim().ToLowerInvariant();
            query = query.Where(p => p.Category == normalized);
        }

        if (!string.IsNullOrWhiteSpace(Currency))
        {
            var currency = Currency.Trim().ToUpperInvariant();
            query = query.Where(p => p.Currency == currency);
        }

        if (MinPrice.HasValue)
        {
            query = query.Where(p => p.Price >= MinPrice.Value);
        }

        if (MaxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= MaxPrice.Value);
        }

        if (IsPublished.HasValue)
        {
            query = query.Where(p => p.IsPublished == IsPublished.Value);
        }

        return query;
    }
}