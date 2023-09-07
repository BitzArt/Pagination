using BitzArt.Pagination.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BitzArt.Pagination.EntityFrameworkCore.Tests
{
    [Collection("Service Collection")]
    public class ToPageAsyncTests
    {
        private readonly InMemoryContext _db;

        public ToPageAsyncTests(TestServiceContainer services)
        {
            _db = services.Db;
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(0, 100)]
        [InlineData(10, 10)]
        public async Task Workflow_CorrectData_IsSuccessful(int offset, int limit)
        {
            var request = new PageRequest(offset, limit);

            var expectedData = await _db.Set<TestEntity>().Skip(offset).Take(limit).ToListAsync();
            var expectedTotal = _db.Set<TestEntity>().Count();
            var expected = new PageResult<TestEntity>(expectedData, request, expectedTotal);

            var result = await _db.Set<TestEntity>().ToPageAsync(request);

            var expectedSerialized = JsonSerializer.Serialize(expected);
            var resultSerialized = JsonSerializer.Serialize(result);

            Assert.Equal(expectedSerialized, resultSerialized);
        }
    }
}
