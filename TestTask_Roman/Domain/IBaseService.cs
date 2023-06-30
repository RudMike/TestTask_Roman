//-----------------------------------------------------------------------
// <copyright file="IBaseService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data;

namespace TestTask_Roman.Domain
{
    /// <summary>
    /// Defines a service for performing CRUD operations on entities in a database.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities being managed.</typeparam>
    /// <typeparam name="TRequest">The type of DTOs that are used to create, update, and delete entities.</typeparam>
    public interface IBaseService<TEntity, TRequest>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="request">The DTO that represents the entity to add.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task's result is the newly added entity.</returns>
        public Task<TEntity> AddAsync(TRequest request, CancellationToken ct = default);

        /// <summary>
        /// Deletes an entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> DeleteAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="request">The DTO that represents the entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> DeleteAsync(TRequest request, CancellationToken ct = default);

        /// <summary>
        /// Retrieves an entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the retrieved entity, or null if no entity was found with the specified ID.</returns>
        public Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="request">The DTO that represents the entity to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task's result is the updated entity.</returns>
        public Task<TEntity> UpdateAsync(TRequest request, CancellationToken ct = default);
    }
}
