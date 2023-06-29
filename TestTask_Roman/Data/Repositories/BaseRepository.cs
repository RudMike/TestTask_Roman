//-----------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TestTask_Roman.Infrastructure;

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Provides a base implementation for a repository of entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository interacts with.</typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContextFactory dbContextFactory;
        private DbSet<TEntity> dbSet = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class with the specified <see cref="DbContextFactory"/>.
        /// </summary>
        /// <param name="dbContextFactory">The factory used to create <see cref="DbContext"/> instances.</param>
        public BaseRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the <see cref="DbSet{TEntity}"/> of entities that the repository interacts with.
        /// </summary>
        protected virtual DbSet<TEntity> DbSet
        {
            get => this.dbSet ??= this.dbContextFactory.Context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(TEntity entity, CancellationToken ct = default)
        {
            await this.DbSet.AddAsync(entity, ct).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var entityToDelete = await this.GetByIdAsync(id, ct)
                .ConfigureAwait(false);

            if (entityToDelete != null)
            {
                await this.DeleteAsync(entityToDelete, ct)
                    .ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            if (this.IsEntityDetached(entity))
            {
                this.dbSet.Attach(entity);
            }

            this.DbSet.Remove(entity);
            await Task.CompletedTask;
        }

        /// <inheritdoc/>
        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await this.DbSet
                .FindAsync(id, ct)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(TEntity updatedEntity, CancellationToken ct = default)
        {
            this.DbSet.Update(updatedEntity);
            await Task.CompletedTask;
        }

        private bool IsEntityDetached(TEntity entity)
        {
            return this.DbSet
                .Entry(entity)
                .State == EntityState.Detached;
        }
    }
}
