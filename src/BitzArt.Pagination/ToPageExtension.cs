using BitzArt.Pagination;

namespace System.Linq
{
    public static class ToPageExtension
    {
        public static PageResult<T> ToPage<T>(this IEnumerable<T> query, int skip, int take)
            => query.ToPage(new PageRequest(skip, take));

        public static PageResult<T> ToPage<T>(this IEnumerable<T> query, PageRequest request)
        {
            var data = query.Skip(request.Offset).Take(request.Limit).AsEnumerable();
            var total = query.Count();

            return new PageResult<T>(data, request, total);
        }
    }
}
