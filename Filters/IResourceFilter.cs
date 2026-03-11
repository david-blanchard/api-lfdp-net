namespace la_foire_des_prix.Filters;

public interface IResourceFilter<TEntity>
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> query);
}