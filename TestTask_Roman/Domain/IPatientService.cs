//-----------------------------------------------------------------------
// <copyright file="IPatientService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Models;
using TestTask_Roman.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Domain
{
    /// <summary>
    /// Defines a service for managing patients.
    /// </summary>
    public interface IPatientService : IDatabaseService<Patient>
    {
        /// <summary>
        /// Retrieves a paged list of patients from the database.
        /// </summary>
        /// <param name="sortColumn">The name of the column to sort by, or null to use the default sort order.</param>
        /// <param name="sortOrder">The sort order to use ("asc" or "desc"), or null to use the default sort order.</param>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a paged list of patients.</returns>
        public Task<PagedList<PatientsResponse>> GetAllAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default);
    }
}
