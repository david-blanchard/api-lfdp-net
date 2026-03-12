namespace LaFoireDesPrix.Filters;

public interface IResourceFilter<TEntity>
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> query);
}