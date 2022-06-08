using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitzArt.Pagination.Models
{
    public class PageRequest
    {
        [FromQuery(Name = "offset")]
        [JsonProperty("offset")]
        public virtual int Offset { get; set; }

        [FromQuery(Name = "limit")]
        [JsonProperty("limit")]
        public virtual int Limit { get; set; }

        public PageRequest() : this(0, 100)
        {
        }

        public PageRequest(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }
    }
}
