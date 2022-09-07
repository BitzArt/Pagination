using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

public class PageResult<T>
{
    [JsonPropertyName("request")]
    public PageRequest? Request { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<T> Data { get; set; }

    private PageResult()
    {
        Data = new List<T>();
    }

    public PageResult(IEnumerable<T> data, int offset, int limit, int total)
        : this(data, new PageRequest(offset, limit), total) { }

    public PageResult(IEnumerable<T> data, PageRequest? request, int total)
    {
        Data = data;
        Count = Data.Count();
        Request = request;
        Total = total;
    }
}
