using Pagination.Tests.Contexts;
using Pagination.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pagination.Tests.Extensions
{
    public static class CreateUsersExtension
    {
        public static void CreateUsers(this InMemoryContext context, int count)
        {
            var users = new List<User>();
            for (int i = 0; i <= count; i++)
                users.Add(new User());
            context.Users.AddRange(users);
        }
    }
}
