//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Defines methods for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task's result is the newly added entity.</returns>
        public Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="updatedEntity">The updated entity.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task's result is the updated entity.</returns>
        public Task<TEntity> UpdateAsync(TEntity updatedEntity, CancellationToken ct = default);

        /// <summary>
        /// Deletes an existing entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteAsync(TEntity entity, CancellationToken ct = default);

        /// <summary>
        /// Deletes an existing entity from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Gets an entity from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation, which returns the entity if found or null otherwise.</returns>
        public Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
