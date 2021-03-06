﻿using BitzArt.Pagination.Tests.EntityFrameworkCore.Contexts;
using BitzArt.Pagination.Tests.Models;
using System.Collections.Generic;

namespace BitzArt.Pagination.Tests.EntityFrameworkCore.Extensions
{
    public static class CreateUsersExtension
    {
        public static void CreateUsers(this InMemoryContext context, int count)
        {
            count *= 2;

            var users = new List<User>();
            for (int i = 0; i < count; i++)
                users.Add(new User());

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
