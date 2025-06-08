namespace BitzArt.Pagination;

/// <summary>
/// A request for a page of items.
/// </summary>
public interface IPageRequest
{
    /// <summary>
    /// Method used to apply constraints specified in the request to a query.
    /// </summary>
    /// <remarks>
    /// This method is only necessary to implement if support for applying constraints to an <see cref="IEnumerable{TSource}"/> is required.
    /// </remarks>
    /// <typeparam name="TSource">Type of the items in the query.</typeparam>
    /// <param name="items">Input items to apply constraints to.</param>
    /// <returns>An <see cref="IEnumerable{TSource}"/> with constraints applied.</returns>
    public IEnumerable<TSource> ApplyConstraints<TSource>(IEnumerable<TSource> items);

    /// <summary>
    /// Method used to apply constraints specified in the request to a query.
    /// </summary>
    /// <remarks>
    /// This method is only necessary to implement if support for applying constraints to an <see cref="IQueryable{TSource}"/> is required.
    /// </remarks>
    /// <typeparam name="TSource">Type of the items in the query.</typeparam>
    /// <param name="query">Query to apply constraints to.</param>
    /// <returns>A query with constraints applied.</returns>
    public IQueryable<TSource> ApplyConstraints<TSource>(IQueryable<TSource> query);
}
