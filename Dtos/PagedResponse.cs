namespace LaFoireDesPrix.Dtos;

public record PaginationMeta(int Page, int PageSize, int TotalItems, int TotalPages)
{
    public bool HasNext => Page < TotalPages;
    public bool HasPrevious => Page > 1;
}

public record PagedResponse<T>(IReadOnlyCollection<T> Data, PaginationMeta Meta);

public static class PagedResponse
{
    public static PagedResponse<T> Create<T>(IReadOnlyCollection<T> data, int page, int pageSize, int total)
    {
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);
        totalPages = totalPages == 0 ? 1 : totalPages;
        var meta = new PaginationMeta(page, pageSize, total, totalPages);
        return new PagedResponse<T>(data, meta);
    }
}