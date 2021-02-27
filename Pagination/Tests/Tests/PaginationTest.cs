using Microsoft.EntityFrameworkCore;
using Pagination.Models;
using Pagination.Tests.Contexts;
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
        [InlineData(0, 10)]
        public void Paginate(int skip, int take)
        {
            using (var context = new InMemoryContext())
            {
                context.Database.EnsureCreated();

                var users = new List<User>();
                for (int i = 0; i<=100; i++)
                    users.Add(new User());
                context.Users.AddRange(users);

                var q = context.Users.AsQueryable();

                var result = q.Skip(skip).Take(take).ToList();

                var pageRequest = new PageRequest(skip, take);
                var paged = q.Paginate(pageRequest).ToList();

                Assert.Equal(result, paged);
            }
        }
    }
}
