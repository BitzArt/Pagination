using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagination.Models
{
    public class PageResult<T>
    {
        public PageRequest Request { get; set; }

        public int Count => Data.Count();

        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
