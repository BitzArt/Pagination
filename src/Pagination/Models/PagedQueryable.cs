using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitzArt.Pagination.Models
{
    public class PagedQueryable<T> : IQueryable<T>
    {
        public PageRequest PageRequest { get; set; }
        public IQueryable<T> Query { get; set; }

        public Type ElementType => Query.ElementType;

        public Expression Expression => Query.Expression;

        public IQueryProvider Provider => Query.Provider;

        public IEnumerator<T> GetEnumerator() => Query.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Query.GetEnumerator();

        public PagedQueryable(IQueryable<T> query, int skip, int take)
        {
            var request = new PageRequest(skip, take);

            PageRequest = request;
            Query = query;
        }

        public PagedQueryable(IQueryable<T> query, PageRequest request)
        {
            PageRequest = request;
            Query = query;
        }
    }
}
