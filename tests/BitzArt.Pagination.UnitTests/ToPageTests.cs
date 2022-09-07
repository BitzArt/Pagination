using System.Linq;
using Xunit;

namespace BitzArt.Pagination.Tests
{
    public class ToPageTests
    {
        [Theory]
        [InlineData(100, 0, 10)]
        [InlineData(100, 10, 10)]
        [InlineData(10, 0, 10)]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, 0)]
        public void ToPage_OnIEnumerable_CorrectResult(int total, int offset, int limit)
        {
            var list = Enumerable.Range(1, total);
            var result = list.ToPage(offset, limit);

            Assert.Equal(total, result.Total);
            Assert.Equal(offset, result.Request.Offset);
            Assert.Equal(limit, result.Request.Limit);
            Assert.Equal(result.Data.Count(), result.Count);

            if (result.Count == 0) return;

            Assert.Equal(list.ElementAt(offset), result.Data.First());
        }
    }
}
