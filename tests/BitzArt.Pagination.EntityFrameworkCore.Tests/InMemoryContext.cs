using BitzArt.Pagination.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BitzArt.Pagination.EntityFrameworkCore
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>();
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
