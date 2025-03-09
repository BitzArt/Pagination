using System.Linq;
using Xunit;

namespace BitzArt.Pagination.Tests;

public class PageRequestTests
{
    [Theory]
    [InlineData(100, 0, 10)]
    [InlineData(100, 0, 100)]
    [InlineData(100, 10, 10)]
    [InlineData(100, 90, 10)]
    public void ApplyConstraints_WithinBoundaries_ShouldFilterCorrectly(int total, int offset, int limit)
    {
        // Arrange
        var list = Enumerable.Range(1, total);
        var request = new PageRequest(offset, limit);

        // Act
        var result = request.ApplyConstraints(list);

        // Assert
        Assert.Equal(list.Skip(offset).Take(limit), result);
    }

    [Theory]
    [InlineData(10, 9, 2)]
    [InlineData(10, 5, 10)]
    [InlineData(100, 50, 100)]
    [InlineData(100, 90, 100)]
    [InlineData(100, 100, 100)]
    [InlineData(0, 10, 10)]
    [InlineData(0, 0, 0)]
    public void ApplyConstraints_CrossingOrOutOfBoundaries_ShouldFilterCorrectly(int total, int offset, int limit)
    {
        // Arrange
        var list = Enumerable.Range(1, total);
        var request = new PageRequest(offset, limit);

        // Act
        var result = request.ApplyConstraints(list);

        // Assert
        Assert.Equal(list.Skip(offset).Take(limit), result);
    }
}
