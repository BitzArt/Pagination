using BitzArt.Pagination.Tests.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BitzArt.Pagination.Tests.EntityFrameworkCore.Contexts
{
    public class InMemoryContext : DbContext
    {
        private static InMemoryContext instance { get; set; } = null;

        public static InMemoryContext Instance
        {
            get
            {
                if (instance == null) instance = new InMemoryContext();
                return instance;
            }
        }

        public DbSet<User> Users { get; set; }

        public InMemoryContext()
        {
            Database.EnsureCreated();
        }

        private static bool Created { get; set; } = false;

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(CreateDb());

        private static DbConnection Connection { get; set; }
        private DbConnection CreateDb()
        {
            Connection = new SqliteConnection("Filename=:memory:");
            Connection.Open();
            return Connection;
        }

    }
}
