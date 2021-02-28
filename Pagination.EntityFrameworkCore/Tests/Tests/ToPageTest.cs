using Pagination.Models;
using Pagination.Tests.Contexts;
using Pagination.Tests.Extensions;
using Pagination.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Pagination.Tests
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
            var context = InMemoryContext.Instance;
            context.CreateUsers(skip + take);

            var request = new PageRequest(skip, take);

            var data = await context.Users.Skip(skip).Take(take).ToListAsync();
            var total = context.Users.Count();
            var result = new PageResult<User>(data, request, total);

            var p = context.Users.Paginate(request);
            var paged = p.ToPage();

            var resultSerialized = JsonConvert.SerializeObject(result);
            var pagedSerialized = JsonConvert.SerializeObject(paged);

            Assert.Equal(resultSerialized, pagedSerialized);
        }
    }
}
