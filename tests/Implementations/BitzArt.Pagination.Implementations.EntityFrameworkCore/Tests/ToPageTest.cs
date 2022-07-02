using BitzArt.Pagination.Implementations.EntityFrameworkCore.Contexts;
using BitzArt.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BitzArt.Pagination.Implementations.EntityFrameworkCore.Tests
{
    public class ToPageTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(0, 100)]
        [InlineData(10, 10)]
        public async Task ToPage(int skip, int take)
        {
            var context = InMemoryContext.Instance; //TODO: Optimize this
            context.CreateUsers(skip + take); //TODO: Optimize this

            var request = new PageRequest(skip, take);

            var data = await context.Users.Skip(skip).Take(take).ToListAsync();
            var total = context.Users.Count();
            var result = new PageResult<User>(data, request, total);

            var paged = context.Users.ToPage(request);
            var pagedAsync = await context.Users.ToPageAsync(request);

            var resultSerialized = JsonConvert.SerializeObject(result);
            var pagedSerialized = JsonConvert.SerializeObject(paged);
            var pagedAsyncSerialized = JsonConvert.SerializeObject(pagedAsync);

            Assert.Equal(resultSerialized, pagedSerialized);
            Assert.Equal(resultSerialized, pagedAsyncSerialized);
        }
    }
}
