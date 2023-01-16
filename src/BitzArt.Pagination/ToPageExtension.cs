using BitzArt.Pagination;

namespace System.Linq;

public static class ToPageExtension
{
    public static PageResult<T> ToPage<T>(this IEnumerable<T> query, int skip, int take)
        => query.ToPage(new PageRequest(skip, take));

    public static PageResult<T> ToPage<T>(this IEnumerable<T> query, PageRequest request)
    {
        if (request.Offset is null) throw new ArgumentException("Offset is null");
        if (request.Limit is null) throw new ArgumentException("Limit is null");

        var data = query.Skip(request.Offset.Value).Take(request.Limit.Value);
        var total = query.Count();

        return new PageResult<T>(data, request, total);
    }
}
