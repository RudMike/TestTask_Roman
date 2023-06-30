//-----------------------------------------------------------------------
// <copyright file="PagedList.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace TestTask_Roman.Utilities
{
    /// <summary>
    /// Represents a paged list of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class PagedList<T>
    {
        private PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            this.Items = items;
            this.Page = page;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the items in the paged list.
        /// </summary>
        public List<T> Items { get; }

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets the total number of items in the list.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Gets a value indicating whether there is a next page in the paged list.
        /// </summary>
        public bool HasNextPage => this.Page * this.PageSize < this.TotalCount;

        /// <summary>
        /// Gets a value indicating whether there is a previous page in the paged list.
        /// </summary>
        public bool HasPreviousPage => this.Page > 1;

        /// <summary>
        /// Creates a new instance of the <see cref="PagedList{T}"/> class asynchronously.
        /// </summary>
        /// <param name="query">The query to page.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A new instance of the <see cref="PagedList{T}"/> class.</returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize, CancellationToken ct = default)
        {
            var totalCount = await query.CountAsync(ct)
                .ConfigureAwait(false);

            var items = await query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct)
                .ConfigureAwait(false);

            return new PagedList<T>(items, page, pageSize, totalCount);
        }
    }
}
