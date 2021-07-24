using BitzArt.Pagination.Interface;
using System;

namespace BitzArt.Pagination
{
    public static class Configuration
    {
        public static Type CustomPageResultType { get; private set; } = null;

        public static void SetPageResult<T>()
            where T : IPageResult
        {
            CustomPageResultType = typeof(T);
        }
    }
}
