using System.Linq;
using System.Text.Json;
using Xunit;

namespace BitzArt.Pagination;

public class SerializationTests
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 0, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(0, 1, 1)]
    [InlineData(10, 0, 10)]
    [InlineData(100, 0, 10)]
    [InlineData(10, 10, 10)]
    public void SerializeAndDeserialize_PageResult_ShouldRemainTheSame(int total, int offset, int limit)
    {
        // Arrange
        var data = Enumerable.Range(1, total);
        var page = data.ToPage(offset, limit);
        var json = JsonSerializer.Serialize(page);

        // Act
        var result = JsonSerializer.Deserialize<PageResult<int, PageRequest>>(json);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(page.Items, result.Items);
        Assert.Equal(page.Request.Offset, result.Request.Offset);
        Assert.Equal(page.Request.Limit, result.Request.Limit);
        Assert.Equal(page.Total, result.Total);
        Assert.Equal(page.Count, result.Count);
    }
}
