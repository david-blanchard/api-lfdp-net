using la_foire_des_prix.Entities;
using Microsoft.EntityFrameworkCore;

namespace la_foire_des_prix.Data;

public static class SeedData
{
    private static readonly string[] Categories =
    {
        "alimentaire", "electromenager", "multimedia", "mode", "maison"
    };

    public static async Task InitializeAsync(AppDbContext context, CancellationToken cancellationToken = default)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);

        if (await context.Products.AnyAsync(cancellationToken))
        {
            return;
        }

        var random = new Random();
        var products = Enumerable.Range(1, 50).Select(index => new Product
        {
            Name = $"Produit {index:000}",
            Description = "Produit de démonstration généré automatiquement",
            Category = Categories[random.Next(Categories.Length)],
            Currency = "EUR",
            Price = Math.Round((decimal)(random.NextDouble() * 450) + 10, 2),
            IsPublished = random.NextDouble() > 0.35,
            StockQuantity = random.Next(0, 500)
        });

        await context.Products.AddRangeAsync(products, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}