using BitzArt.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BitzArt.Pagination.Tests
{
    public class ConvertTests
    {
        [Fact]
        public void ToPage_CorrectSource_CorrectResult()
        {
            var sourceData = new List<TestSourceClass>();
            for (int i = 1; i <= 10; i++) sourceData.Add(new TestSourceClass($"test object {i}"));

            var sourcePage = new PageResult<TestSourceClass>(sourceData, null, 10);
            var resultPage = sourcePage.Convert(x => new TestResultClass(x));

            for (int i = 1; i <= 10; i++)
            {
                var source = sourcePage.Data.ElementAt(i - 1);
                var result = resultPage.Data.ElementAt(i - 1).Source;

                Assert.Equal(source, result);
                Assert.Equal(source.Name, result.Name);
            }
        }
    }
}
