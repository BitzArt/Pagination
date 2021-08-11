using BitzArt.Pagination.Models;
using System;
using System.Linq;

namespace BitzArt.Pagination
{
    public static class ConvertExtension
    {
        public static PageResult<TResult> Convert<TSource, TResult>(this PageResult<TSource> source, Func<TSource, TResult> selector)
        {
            var data = source.Data.Select(selector);
            return new PageResult<TResult>(data, source.Request, source.Total);
        }
    }
}
