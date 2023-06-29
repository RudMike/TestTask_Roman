//-----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TestTask_Roman.Domain;

namespace TestTask_Roman.Infrastructure.Repositories
{
    /// <summary>
    /// Provides a unit of work abstraction for a database context.
    /// </summary>
    /// <typeparam name="TContext">The type of <see cref="DbContext"/> used by the unit of work.</typeparam>
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        private readonly DbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class with the specified <see cref="DbContextFactory"/>.
        /// </summary>
        /// <param name="dbContextFactory">The factory used to create DbContext instances.</param>
        public UnitOfWork(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <inheritdoc/>
        public Task<int> SaveAsync(CancellationToken ct = default)
        {
            return this.dbContextFactory
                .Context
                .SaveChangesAsync(ct);
        }
    }
}
