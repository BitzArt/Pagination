using BitzArt.Pagination.Models;
using System;
using System.Linq;

namespace BitzArt.Pagination
{
    public static class ConvertExtension
    {
        /// <summary>
        /// Converts the Data of a PageResult into something else using selector
        /// </summary>
        /// <returns>A converted PageResult</returns>
        public static PageResult<TResult> Convert<TSource, TResult>(this PageResult<TSource> source, Func<TSource, TResult> selector)
        {
            var data = source.Data.Select(selector);
            return new PageResult<TResult>(data, source.Request, source.Total);
        }
    }
}
