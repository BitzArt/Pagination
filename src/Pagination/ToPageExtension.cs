using BitzArt.Pagination.Models;
using System.Collections.Generic;

namespace System.Linq
{
    public static class ToPageExtension
    {
        public static PageResult<T> ToPage<T>(this IEnumerable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return query.ToPage(request);
        }

        public static PageResult<T> ToPage<T>(this IEnumerable<T> query, PageRequest request)
        {
            var data = query.Skip(request.Skip).Take(request.Take).AsEnumerable();
            var total = query.Count();

            return new PageResult<T>(data, request, total);
        }
    }
}
