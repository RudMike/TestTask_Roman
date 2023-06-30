//-----------------------------------------------------------------------
// <copyright file="SortHelper.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using TestTask_Roman.Constants;

namespace TestTask_Roman.Data
{
    /// <summary>
    /// Provides functionality for sorting collections of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities being sorted.</typeparam>
    public static class SortHelper<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Applies sorting to a collection of entities using the specified key selector and sort order.
        /// </summary>
        /// <param name="query">The query to sort.</param>
        /// <param name="keySelector">The key selector to use for sorting.</param>
        /// <param name="sortOrder">The sort order to apply. Valid values are "asc" or "desc".</param>
        /// <returns>The sorted query.</returns>
        public static IQueryable<TEntity> ApplySort(IQueryable<TEntity> query, Expression<Func<TEntity, object>> keySelector, string? sortOrder)
        {
            if (string.Compare(sortOrder, RoutingConstants.ByDescending, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return query.OrderByDescending(keySelector);
            }
            else
            {
                return query.OrderBy(keySelector);
            }
        }
    }
}
