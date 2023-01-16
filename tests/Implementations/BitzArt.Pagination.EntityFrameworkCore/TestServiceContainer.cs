using BitzArt.Pagination.Models;
using Xunit;

namespace BitzArt.Pagination.EntityFrameworkCore
{
    [CollectionDefinition("Service Collection")]
    public class ContainerCollection : ICollectionFixture<TestServiceContainer> { }

    public class TestServiceContainer
    {
        public readonly InMemoryContext Db;
        public TestServiceContainer()
        {
            Db = new InMemoryContext();
            Db.Database.EnsureCreated();
            GenerateEntities(100);
        }

        private void GenerateEntities(int count)
        {
            for (int i = 0; i < count; i++) Db.Add(new TestEntity());
            Db.SaveChanges();
        }
    }
}
