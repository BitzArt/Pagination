using System;
using System.Collections.Generic;
using System.Text;

namespace Pagination.Models
{
    public class PageRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
