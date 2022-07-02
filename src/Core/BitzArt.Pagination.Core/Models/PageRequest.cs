using Newtonsoft.Json;

namespace BitzArt.Pagination
{
    public class PageRequest
    {
        [JsonProperty("offset")]
        public virtual int Offset { get; set; }

        [JsonProperty("limit")]
        public virtual int Limit { get; set; }

        public PageRequest() : this(0, 100) { }

        public PageRequest(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }
    }
}
