//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace TestTask_Roman.Domain
{
    /// <summary>
    /// Defines a unit of work abstraction for a database context.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    public interface IUnitOfWork<out TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Saves all changes made in this unit of work to the underlying database asynchronously.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> SaveAsync(CancellationToken ct = default);
    }
}
