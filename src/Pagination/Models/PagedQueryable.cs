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
    }
}
