using System.Collections;
using System.Text.Json.Serialization;

namespace BitzArt.Pagination;

public class PageResult
{
    [JsonPropertyName("request")]
    public PageRequest? Request { get; set; }

    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonIgnore]
    protected IEnumerable? _data;

    [JsonPropertyName("data")]
    public virtual IEnumerable<object>? Data
    {
        get => _data is IEnumerable<object> dataOb ? dataOb : _data?.Cast<object>();
        set => _data = value;
    }

    public PageResult() { }

    public PageResult(IEnumerable<object>? data, int? offset, int? limit, int? total)
        : this(data, new PageRequest(offset, limit), total) { }

    public PageResult(IEnumerable<object>? data, PageRequest? request, int? total)
    {
        Data = data;
        Count = Data?.Count();
        Request = request;
        Total = total;
    }
}

public class PageResult<T> : PageResult
{
    [JsonPropertyName("data")]
    public new IEnumerable<T>? Data
    {
        get => (IEnumerable<T>?)_data;
        set => _data = value;
    }

    public PageResult() : base() { }

    public PageResult(IEnumerable<T> data, int? offset, int? limit, int? total)
        : this(data, new PageRequest(offset, limit), total) { }

    public PageResult(IEnumerable<T>? data, PageRequest? request, int? total)
    {
        Data = data;
        Count = Data?.Count();
        Request = request;
        Total = total;
    }
}
