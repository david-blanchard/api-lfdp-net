using System.Linq.Expressions;
using LaFoireDesPrix.Dtos;

namespace LaFoireDesPrix.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, PaginationQuery pagination, IDictionary<string, LambdaExpression> sortMap, string defaultKey)
    {
        var direction = pagination.SortDirection ?? "desc";
        var sortKey = pagination.SortBy ?? string.Empty;

        if (!sortMap.TryGetValue(sortKey, out var selector))
        {
            selector = sortMap[defaultKey];
        }

        return ApplyOrdering(query, selector, direction.Equals("asc", StringComparison.OrdinalIgnoreCase));
    }

    private static IQueryable<T> ApplyOrdering<T>(IQueryable<T> source, LambdaExpression selector, bool ascending)
    {
        var methodName = ascending ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);
        var method = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2);

        var genericMethod = method.MakeGenericMethod(typeof(T), selector.ReturnType);
        return (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, selector })!;
    }
}