using Pagination.Interfaces;
using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pagination.EntityFrameworkCore.Extensions
{
    public static class ToPageExtension
    {
        public static PageResult<T> ToPage<T>(this IQueryable<T> query)
        {
            //if ((query is IPagedQueryable<T>) == false)

            return new PageResult<T>();
        }
    }
}
