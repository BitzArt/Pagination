using BitzArt.Pagination.Models;

namespace BitzArt.Pagination.Interface
{
    public interface ICustomPageResult<T>
    {
        object Map(PageResult<T> input);
    }
}
