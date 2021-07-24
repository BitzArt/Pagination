using BitzArt.Pagination.Models;

namespace BitzArt.Pagination.Interface
{
    public interface IPageResult
    {
        IPageResult Convert(PageResult pageResult);
    }
}
