using Microsoft.EntityFrameworkCore;
using Pagination.Models;
using Pagination.Tests.Contexts;
using Pagination.Tests.Extensions;
using Pagination.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Paginate(int skip, int take)
        {
            using (var context = new InMemoryContext())
            {
                context.CreateUsers(take);

                var q = context.Users.AsQueryable();

                var result = q.Skip(skip).Take(take).ToList();

                var pageRequest = new PageRequest(skip, take);
                var paged1 = q.Paginate(pageRequest).ToList();

                var paged2 = q.Paginate(skip, take).ToList();

                Assert.Equal(result, paged1);
                Assert.Equal(result, paged2);
            }
        }
    }
}
