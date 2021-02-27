using Pagination.Interfaces;
using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagination.Extensions
{
    public static class PaginateExtension
    {

        public static IPagedQueryable<T> Paginate<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return Paginate<T>(query, request);
        }

        public static IPagedQueryable<T> Paginate<T>(this IQueryable<T> query, PageRequest request = null)
        {
            if (request == null)
                return query as IPagedQueryable<T>;

            query = query
                .Skip(request.Skip)
                .Take(request.Take);

            var result = query as IPagedQueryable<T>;

            result.PageRequest = request;

            return result;
        }
    }
}
