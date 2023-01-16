using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BitzArt.Pagination
{
    public class PageResultTests
    {
        [Fact]
        public void PageResult_ToBaseClass_RetainsData()
        {
            var list = new List<string> { "a", "b", "c" };

            var pageResultGeneric = new PageResult<string> { Data = list };
            var pageResultBase = pageResultGeneric as PageResult;

            Assert.Equal(pageResultBase.Data.Count(), list.Count);
        }
    }
}
