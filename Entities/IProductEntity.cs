namespace LaFoireDesPrix.Entities;

public interface IProductEntity : ICategoryEntity
{
    int Id { get; }
    string? Name { get; }
    string? Description { get; }
    string? MoreInfo { get; }
    decimal Price { get; }
    Brand? Brand { get; }
}
