using BitzArt.Pagination.Models;
using BitzArt.Pagination.Tests.Contexts;
using BitzArt.Pagination.Tests.Extensions;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BitzArt.Pagination.Tests
{
    public class PaginationTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(0, 100)]
        [InlineData(10, 10)]
        public async Task Paginate(int skip, int take)
        {
            var context = InMemoryContext.Instance;
            context.CreateUsers(skip + take);

            var q = context.Users.AsQueryable();
            var request = new PageRequest(skip, take);

            var result = q.Skip(skip).Take(take).ToList();

            var paged1 = q.Paginate(skip, take).ToList();
            var paged2 = q.Paginate(request).ToList();

            var resultSerialized = JsonConvert.SerializeObject(result);
            var pagedSerialized1 = JsonConvert.SerializeObject(paged1);
            var pagedSerialized2 = JsonConvert.SerializeObject(paged2);

            Assert.Equal(resultSerialized, pagedSerialized1);
            Assert.Equal(resultSerialized, pagedSerialized2);
        }
    }
}
