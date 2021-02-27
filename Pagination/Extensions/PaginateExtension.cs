using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Pagination
{
    public static class PaginateExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return Paginate<T>(query, request);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PageRequest request = null)
        {
            var result = new PagedQueryable<T>();
            result.Query = query;

            if (request == null)
                return result;

            query = query
                .Skip(request.Skip)
                .Take(request.Take);

            result.Query = query;
            result.PageRequest = request;

            return result;
        }
    }
}
