using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagination.Interfaces
{
    public interface IPagedQueryable<T> : IQueryable<T>
    {
        PageRequest PageRequest { get; set; }
        IQueryable<T> Query { get; set; }
    }
}
