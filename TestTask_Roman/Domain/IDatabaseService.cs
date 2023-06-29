//-----------------------------------------------------------------------
// <copyright file="IDatabaseService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Domain
{
    /// <summary>
    /// Defines a service for performing CRUD operations on entities in a database.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities being managed.</typeparam>
    public interface IDatabaseService<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        /// <remarks>Id property of the entity can be ignored.</remarks>
        public Task<int> AddAsync(TEntity entity, CancellationToken ct = default);

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
        /// <param name="entity">The entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> DeleteAsync(TEntity entity, CancellationToken ct = default);

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
        /// <param name="entity">The entity to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public Task<int> UpdateAsync(TEntity entity, CancellationToken ct = default);
    }
}
