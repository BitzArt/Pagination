using System;
using System.Linq;
using Xunit;

namespace BitzArt.Pagination.Tests;

public class ToPageTests
{
    [Theory]
    [InlineData(0, 10)]
    [InlineData(10, 10)]
    [InlineData(10, 0)]
    [InlineData(0, 0)]
    [InlineData(0, 100)]
    [InlineData(0, 1000)]
    [InlineData(1000, 1000)]
    public void ToPage_OnEnumerable_ShouldHaveCorrectPageRequest(int offset, int limit)
    {
        // Arrange
        var list = Enumerable.Range(1, 100);

        // Act
        var result = list.ToPage(offset, limit);

        // Assert
        Assert.IsType<PageRequest>(result.Request);
        var pageRequest = (PageRequest)result.Request;

        Assert.Equal(offset, pageRequest.Offset);
        Assert.Equal(limit, pageRequest.Limit);
    }

    [Theory]
    [InlineData(100, 0, 10)]
    [InlineData(100, 10, 10)]
    [InlineData(10, 0, 10)]
    [InlineData(0, 0, 1)]
    [InlineData(0, 1, 1)]
    [InlineData(0, 1, 0)]
    public void ToPage_OnEnumerable_ShouldApplyConstraints(int total, int offset, int limit)
    {
        // Arrange
        var list = Enumerable.Range(1, total);
        var request = new PageRequest(offset, limit);

        var expectedItems = request.ApplyConstraints(list);

        // Act
        var result = list.ToPage(offset, limit);

        // Assert
        Assert.Equal(expectedItems, result.Items);
    }

    [Theory]
    [InlineData(100, 0, 10)]
    [InlineData(100, 10, 10)]
    [InlineData(10, 0, 10)]
    [InlineData(0, 0, 1)]
    [InlineData(0, 1, 1)]
    [InlineData(0, 1, 0)]
    public void ToPage_OnEnumerable_TotalShouldBeCorrect(int total, int offset, int limit)
    {
        // Arrange
        var list = Enumerable.Range(1, total);

        // Act
        var result = list.ToPage(offset, limit);

        // Assert
        Assert.Equal(result.Items.Count(), result.Count);
        Assert.Equal(total, result.Total);
    }
}
