using Pagination.Interfaces;
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
        public static IPagedQueryable<T> Paginate<T>(this IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);
            return Paginate<T>(query, request);
        }

        public static IPagedQueryable<T> Paginate<T>(this IQueryable<T> query, PageRequest request = null)
        {
            if (query is PagedQueryable<T>) return (query as PagedQueryable<T>);

            var result = new PagedQueryable<T>();
            result.Query = query;
            result.UnpaginatedQuery = query;

            if (request == null) return result;
            result.PageRequest = request;
            result.Query = query.Skip(request.Skip).Take(request.Take);

            return result;
        }
    }
}
