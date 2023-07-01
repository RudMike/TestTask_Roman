﻿//-----------------------------------------------------------------------
// <copyright file="IReportRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Utilities;

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Represents a repository for generating reports.
    /// </summary>
    /// <typeparam name="TReport">The type of report generated by the repository.</typeparam>
    public interface IReportRepository<TReport>
    {
        /// <summary>
        /// Retrieves a paged list of <typeparamref name="TReport"/> objects according to specified sorting and paging parameters.
        /// </summary>
        /// <param name="sortColumn">The column to sort the results by. Uses default value if <see langword="null"/>.</param>
        /// <param name="sortOrder">The order in which to sort the results. Uses default value if <see langword="null"/>.</param>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items to include per page.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation that returns a paged list of <typeparamref name="TReport"/> objects.</returns>
        public Task<PagedList<TReport>> GetReportAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default);
    }
}
