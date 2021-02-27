using Pagination.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pagination.Models
{
    public class PagedQueryable<T> : IPagedQueryable<T>, IQueryable<T>
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
