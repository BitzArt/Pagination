using System.Collections.Generic;
using System.Linq;

namespace BitzArt.Pagination.Models
{
    public class PageResult
    {
        public PageRequest Request { get; set; }

        public int Count { get; set; }

        public int Total { get; set; }

        public virtual IEnumerable<object> Data { get; set; }

        public PageResult() { }

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
        public new IEnumerable<T> Data { get; set; }

        public PageResult(IEnumerable<T> data, PageRequest request, int total)
        {
            Data = data;
            Count = Data.Count();
            Request = request;
            Total = total;
        }
    }
}
