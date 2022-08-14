using System;
using System.Collections.Generic;
using System.Linq;

namespace BitzArt.Pagination
{
    public class PageResult
    {
        public PageRequest Request { get; set; }

        public int Count { get; set; }

        public int Total { get; set; }

        public virtual IEnumerable<object> Data { get; set; }

        private protected PageResult() { }

        public PageResult(IEnumerable<object> data, int offset, int limit, int total)
            : this(data, new PageRequest(offset, limit), total) { }

        public PageResult(IEnumerable<object> data, PageRequest request, int total)
        {
            Data = data;
            Count = Data.Count();
            Request = request;
            Total = total;
        }
    }

    public class PageResult<T> : PageResult
    {
        public new IEnumerable<T> Data { get => base.Data.Cast<T>(); set => base.Data = value.Cast<object>(); }

        private protected PageResult() : base() { }

        public PageResult(IEnumerable<T> data, int offset, int limit, int total) : this(data, new PageRequest(offset, limit), total) { }

        public PageResult(IEnumerable<T> data, PageRequest request, int total) : base(data.Cast<object>(), request, total) { }

        /// <summary>
        /// Converts the Data of a PageResult into something else using a selector
        /// </summary>
        /// <returns>A converted PageResult</returns>
        public PageResult<TResult> Convert<TResult>(Func<T, TResult> selector)
        {
            var data = Data.Select(selector);
            return new PageResult<TResult>(data, Request, Total);
        }
    }
}
