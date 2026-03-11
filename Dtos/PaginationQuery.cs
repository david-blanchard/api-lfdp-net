namespace la_foire_des_prix.Dtos;

public class PaginationQuery
{
    private const int MaxPageSize = 100;
    private int _page = 1;
    private int _pageSize = 25;

    public int Page
    {
        get => _page;
        set => _page = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value switch
        {
            < 1 => 1,
            > MaxPageSize => MaxPageSize,
            _ => value
        };
    }

    public string? SortBy { get; set; } = "createdAt";
    public string SortDirection { get; set; } = "desc";
}