namespace BitzArt.Pagination;

/// <summary>
/// Extension methods for calculating the total number of pages for <see cref="PageResult"/>.
/// </summary>
public static class PageResultExtensions
{
    /// <summary>
    /// Gets the total number of pages using the <see cref="PageRequest.Limit"/> value.
    /// </summary>
    /// <typeparam name="T">Type of items contained in the page result.</typeparam>
    /// <param name="pageResult">The page result to evaluate.</param>
    /// <returns>The total number of pages.</returns>
    public static int GetPageCount<T>(this PageResult<T, PageRequest> pageResult)
        => GetPageCount(pageResult.Total!.Value, pageResult.Request!.Limit!.Value);

    /// <summary>
    /// Gets the total number of pages using a specified page size.
    /// </summary>
    /// <param name="pageResult">The page result containing total item count.</param>
    /// <param name="pageSize">The size of a page.</param>
    /// <returns>The total number of pages.</returns>
    public static int GetPageCount(this PageResult pageResult, int pageSize)
        => GetPageCount(pageResult.Total!.Value, pageSize);

    /// <summary>
    /// Calculates the number of pages for the provided total item count and page size.
    /// </summary>
    /// <param name="totalItems">Total number of items.</param>
    /// <param name="pageSize">Number of items per page.</param>
    /// <returns>The calculated number of pages.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="totalItems"/> is negative or
    /// when <paramref name="pageSize"/> is less than or equal to zero.
    /// </exception>
    private static int GetPageCount(int totalItems, int pageSize)
    {
        if (totalItems < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(totalItems), "Total items cannot be negative.");
        }

        if (pageSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");
        }

        return (int)Math.Ceiling((double)totalItems / pageSize);
    }
}