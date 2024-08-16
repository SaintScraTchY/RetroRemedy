namespace RetroRemedy.Core.Common;

public class PaginatedResult<TEntity>(int pageIndex, int pageSize, long totalCount, IEnumerable<TEntity> data)
{
    public int CurrentIndex { get; set; } = pageIndex;
    public int TotalPages { get; set; } = (int)Math.Ceiling(totalCount / (double)pageSize);
    public int PageSize { get; set; } = pageSize;
    public long TotalCount { get; set; } = totalCount;
    public IEnumerable<TEntity> Data { get; set; } = data;
}