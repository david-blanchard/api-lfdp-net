using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using LaFoireDesPrix.Data;
using LaFoireDesPrix.Dtos;
using LaFoireDesPrix.Entities;
using LaFoireDesPrix.Extensions;
using LaFoireDesPrix.Filters;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaFoireDesPrix.Endpoints;

public static class ProductEndpoints
{
    private static readonly Dictionary<string, LambdaExpression> SortMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["id"] = (Expression<Func<Product, int>>)(p => p.Id),
        ["name"] = (Expression<Func<Product, string>>)(p => p.Name),
        ["price"] = (Expression<Func<Product, decimal>>)(p => p.Price),
        ["category"] = (Expression<Func<Product, string>>)(p => p.Category),
        ["createdAt"] = (Expression<Func<Product, DateTimeOffset>>)(p => p.CreatedAt),
        ["updatedAt"] = (Expression<Func<Product, DateTimeOffset>>)(p => p.UpdatedAt)
    };

    public static RouteGroupBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products")
            .WithTags("Products");

        group.MapGet("/", async Task<Ok<PagedResponse<ProductResponse>>> (
            AppDbContext db,
            [AsParameters] ProductFilter filter,
            [AsParameters] PaginationQuery pagination) =>
        {
            var query = filter.Apply(db.Products.AsQueryable());
            var total = await query.CountAsync();

            var items = await query
                .ApplySorting(pagination, SortMap, "createdAt")
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(p => ProductResponse.FromEntity(p))
                .ToListAsync();

            return TypedResults.Ok(PagedResponse.Create(items, pagination.Page, pagination.PageSize, total));
        })
        .WithName("listProducts")
        .WithSummary("Liste paginée filtrable des produits");

        group.MapGet("/{id:int}", async Task<Results<Ok<ProductResponse>, NotFound>> (int id, AppDbContext db) =>
        {
            var entity = await db.Products.FindAsync(id);
            return entity is null ? TypedResults.NotFound() : TypedResults.Ok(ProductResponse.FromEntity(entity));
        })
        .WithName("getProduct");

        group.MapPost("/", async Task<Results<Created<ProductResponse>, ValidationProblem>> (
            AppDbContext db,
            [FromBody] ProductInput input) =>
        {
            if (!TryValidate(input, out var errors))
            {
                return TypedResults.ValidationProblem(errors);
            }

            var entity = input.ToEntity();
            db.Products.Add(entity);
            await db.SaveChangesAsync();
            var response = ProductResponse.FromEntity(entity);
            return TypedResults.Created($"/api/products/{entity.Id}", response);
        })
        .WithName("createProduct");

        group.MapPut("/{id:int}", async Task<Results<Ok<ProductResponse>, NotFound, ValidationProblem>> (
            int id,
            AppDbContext db,
            [FromBody] ProductInput input) =>
        {
            if (!TryValidate(input, out var errors))
            {
                return TypedResults.ValidationProblem(errors);
            }

            var entity = await db.Products.FindAsync(id);
            if (entity is null)
            {
                return TypedResults.NotFound();
            }

            input.ApplyTo(entity);
            await db.SaveChangesAsync();
            return TypedResults.Ok(ProductResponse.FromEntity(entity));
        })
        .WithName("updateProduct");

        group.MapPatch("/{id:int}", async Task<Results<Ok<ProductResponse>, NotFound>> (
            int id,
            AppDbContext db,
            [FromBody] Dictionary<string, object> patch) =>
        {
            var entity = await db.Products.FindAsync(id);
            if (entity is null)
            {
                return TypedResults.NotFound();
            }

            if (patch.TryGetValue(nameof(Product.Name), out var name) && name is string strName)
            {
                entity.Name = strName;
            }

            if (patch.TryGetValue(nameof(Product.Description), out var description))
            {
                entity.Description = description as string;
            }

            if (patch.TryGetValue(nameof(Product.Price), out var price) && decimal.TryParse(price.ToString(), out var parsedPrice))
            {
                entity.Price = decimal.Round(parsedPrice, 2, MidpointRounding.ToEven);
            }

            if (patch.TryGetValue(nameof(Product.Category), out var category) && category is string strCategory)
            {
                entity.Category = strCategory.Trim().ToLowerInvariant();
            }

            if (patch.TryGetValue(nameof(Product.Currency), out var currency) && currency is string strCurrency)
            {
                entity.Currency = strCurrency.Trim().ToUpperInvariant();
            }

            if (patch.TryGetValue(nameof(Product.IsPublished), out var published) && bool.TryParse(published.ToString(), out var parsedPublished))
            {
                entity.IsPublished = parsedPublished;
            }

            if (patch.TryGetValue(nameof(Product.StockQuantity), out var stock) && int.TryParse(stock.ToString(), out var parsedStock))
            {
                entity.StockQuantity = parsedStock;
            }

            entity.Touch();
            await db.SaveChangesAsync();
            return TypedResults.Ok(ProductResponse.FromEntity(entity));
        })
        .WithName("patchProduct");

        group.MapDelete("/{id:int}", async Task<Results<NoContent, NotFound>> (int id, AppDbContext db) =>
        {
            var entity = await db.Products.FindAsync(id);
            if (entity is null)
            {
                return TypedResults.NotFound();
            }

            db.Products.Remove(entity);
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        })
        .WithName("deleteProduct");

        return group;
    }

    private static bool TryValidate(ProductInput input, out Dictionary<string, string[]> errors)
    {
        var validationContext = new ValidationContext(input);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(input, validationContext, validationResults, true);

        errors = validationResults
            .SelectMany(result => result.MemberNames.DefaultIfEmpty(string.Empty),
                (result, member) => new { member, result.ErrorMessage })
            .GroupBy(x => x.member, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.Select(x => x.ErrorMessage ?? string.Empty).ToArray());

        return isValid;
    }
}
