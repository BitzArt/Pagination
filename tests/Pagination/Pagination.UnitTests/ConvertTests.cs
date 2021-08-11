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
            var data = new List<TestSourceClass>();
            for (int i = 1; i <= 10; i++) data.Add(new TestSourceClass($"test object {i}"));

            var source = new PageResult<TestSourceClass>(data, null, 10);
            var converted = source.Convert(x => new TestResultClass(x));

            for (int i = 1; i <= 10; i++)
            {
                Assert.Equal(source.Data.ElementAt(i - 1), converted.Data.ElementAt(i - 1).Source);
            }
        }
    }
}
