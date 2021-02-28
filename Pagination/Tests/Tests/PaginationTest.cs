using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pagination.Models;
using Pagination.Tests.Contexts;
using Pagination.Tests.Extensions;
using Pagination.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pagination.Tests
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

            var result = await q.Skip(skip).Take(take).ToListAsync();

            var paged1 = await q.Paginate(skip, take).ToListAsync();
            var paged2 = await q.Paginate(request).ToListAsync();

            var resultSerialized = JsonConvert.SerializeObject(result);
            var pagedSerialized1 = JsonConvert.SerializeObject(paged1);
            var pagedSerialized2 = JsonConvert.SerializeObject(paged2);

            Assert.Equal(resultSerialized, pagedSerialized1);
            Assert.Equal(resultSerialized, pagedSerialized2);
        }
    }
}
