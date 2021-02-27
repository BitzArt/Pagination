using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Pagination.Tests.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Pagination.Tests.Contexts
{
    public class InMemoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public InMemoryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(CreateDb());

        private static DbConnection Connection { get; set; }
        private static DbConnection CreateDb()
        {
            Connection = new SqliteConnection("Filename=:memory:");
            Connection.Open();
            return Connection;
        }

    }
}
