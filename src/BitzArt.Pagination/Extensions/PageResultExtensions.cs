namespace BitzArt.Pagination;

/// <summary>
/// Extension methods for calculating the total number of pages for <see cref="PageResult"/>.
/// </summary>
public static class PageResultExtensions
{
    /// <summary>
    /// Gets the total number of pages using <see cref="PageRequest.Limit"/>.
    /// </summary>
    /// <typeparam name="T">Type of items contained in the page result.</typeparam>
    /// <param name="pageResult">The page result to evaluate.</param>
    /// <returns>Total number of pages in a <see cref="PageResult"/>.</returns>
    public static int GetPageCount<T>(this PageResult<T, PageRequest> pageResult)
    {
        if (pageResult.Request is null)
        {
            throw new InvalidOperationException("Unable to get page count: page request is null.");
        }
        
        if (pageResult.Request.Limit is null)
        {
            throw new InvalidOperationException("Unable to get page count: limit is null.");
        }
        
        return GetPageCount(pageResult.Total, pageResult.Request!.Limit!.Value);
    } 
    
    /// <summary>
    /// Gets the total number of pages using a specified page size.
    /// </summary>
    /// <param name="pageResult">The page result containing total item count.</param>
    /// <param name="pageSize">Size of a page.</param>
    /// <returns>Total number of pages in a <see cref="PageResult"/>.</returns>
    public static int GetPageCount(this PageResult pageResult, int pageSize)
        => GetPageCount(pageResult.Total, pageSize);

    /// <summary>
    /// Calculates the number of pages for the provided total item count and page size.
    /// </summary>
    /// <param name="totalItems">Total number of items.</param>
    /// <param name="pageSize">Number of items per page.</param>
    /// <returns>The calculated number of pages.</returns>
    private static int GetPageCount(int? totalItems, int pageSize) => totalItems switch
    {
        null => throw new InvalidOperationException("Unable to get page count: total item count is null."),
        
        < 0 => throw new InvalidOperationException("Unable to get page count: total item count is negative."),
        
        _ when pageSize <= 0 => throw new InvalidOperationException($"Unable to get page count: page size '{pageSize}' is invalid."),
        
        _ => (int)Math.Ceiling((double)totalItems / pageSize)
    };
}