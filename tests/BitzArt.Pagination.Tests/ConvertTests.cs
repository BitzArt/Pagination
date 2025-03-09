using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BitzArt.Pagination.Tests;

public class ConvertTests
{
    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    public void Convert_OnGoodSource_ShouldReturnCorrectResult(int count)
    {
        // Arrange
        var sourceData = new List<TestSourceClass>();
        for (int i = 0; i < count; i++) sourceData.Add(new TestSourceClass($"test object {i + 1}"));

        var sourcePage = sourceData.ToPage(0, count);

        // Act
        var resultPage = sourcePage.Convert(x => x.ToResult());

        // Assert
        for (int i = 0; i < count; i++)
        {
            var source = sourcePage.Items.ElementAt(i);
            var result = resultPage.Items.ElementAt(i);

            Assert.Equal(source, result.Source);
            Assert.Equal(source.Name, result.Source.Name);
        }
    }

    private class TestSourceClass
    {
        public string Name { get; set; }

        public TestSourceClass(string name)
        {
            Name = name;
        }

        public TestResultClass ToResult() => new(this);
    }

    private class TestResultClass
    {
        public TestSourceClass Source;

        public TestResultClass(TestSourceClass source)
        {
            Source = source;
        }
    }
}
