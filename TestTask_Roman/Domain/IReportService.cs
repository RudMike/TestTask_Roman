﻿//-----------------------------------------------------------------------
// <copyright file="IReportService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Domain
{
    /// <summary>
    /// Represents a database service that can generate reports of type <typeparamref name="TReport"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities managed by the database service.</typeparam>
    /// <typeparam name="TReport">The type of reports generated by the database service.</typeparam>
    /// <typeparam name="TRequest">The type of DTOs that are used to create, update, and delete entities.</typeparam>
    public interface IReportService<TEntity, TReport, TRequest> : IBaseService<TEntity, TRequest>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Retrieves a paged list of <typeparamref name="TReport"/> objects according to specified sorting and paging parameters.
        /// </summary>
        /// <param name="sortColumn">The column to sort the results by. Uses default value if <see langword="null"/>.</param>
        /// <param name="sortOrder">The order in which to sort the results. Uses default value if <see langword="null"/>.</param>
        /// <param name="page">The page number to retrieve, or <c>null</c> to use default value.</param>
        /// <param name="pageSize">The number of items to include per page. Uses default value if <see langword="null"/>.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation that returns a paged list of <typeparamref name="TReport"/> objects.</returns>
        public Task<PagedList<TReport>> GetReportAsync(string? sortColumn, string? sortOrder, int? page, int? pageSize, CancellationToken ct = default);
    }
}
