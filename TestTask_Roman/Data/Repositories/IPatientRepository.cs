//-----------------------------------------------------------------------
// <copyright file="IPatientRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Models;
using TestTask_Roman.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Represents a repository for managing <see cref="Patient"/> entities.
    /// </summary>
    public interface IPatientRepository : IRepository<Patient>
    {
        /// <summary>
        /// Retrieves a paged list of <see cref="PatientsResponse"/> objects according to specified sorting and paging parameters.
        /// </summary>
        /// <param name="sortColumn">The column to sort the results by.</param>
        /// <param name="sortOrder">The order in which to sort the results.</param>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items to include per page.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation that returns a paged list of <see cref="PatientsResponse"/> objects.</returns>
        public Task<PagedList<PatientsResponse>> GetAllAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default);
    }
}
