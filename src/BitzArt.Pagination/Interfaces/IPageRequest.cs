namespace BitzArt.Pagination;

/// <summary>
/// A request for a page of items.
/// </summary>
public interface IPageRequest
{
    /// <summary>
    /// Method used to apply constraints specified in the request to a query.
    /// </summary>
    /// <typeparam name="TSource">Type of the items in the query.</typeparam>
    /// <param name="query">Original query.</param>
    /// <returns>A query with constraints applied.</returns>
    public IEnumerable<TSource> ApplyConstraints<TSource>(IEnumerable<TSource> query);

    /// <inheritdoc cref="ApplyConstraints{TSource}(IEnumerable{TSource})"/>
    public IQueryable<TSource> ApplyConstraints<TSource>(IQueryable<TSource> query);
}
