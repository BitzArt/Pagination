using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

public class PageRequest
{
    [JsonPropertyName("offset")]
    public virtual int Offset { get; set; }

    [JsonPropertyName("limit")]
    public virtual int Limit { get; set; }

    public PageRequest() : this(0, 100) { }

    public PageRequest(int offset, int limit)
    {
        Offset = offset;
        Limit = limit;
    }
}
