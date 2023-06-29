//-----------------------------------------------------------------------
// <copyright file="DatabaseBaseService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using TestTask_Roman.Data;
using TestTask_Roman.Data.Contexts;
using TestTask_Roman.Data.Repositories;
using TestTask_Roman.Domain;
using TestTask_Roman.Infrastructure.Exceptions;
using TestTask_Roman.Infrastructure.Validators;

namespace TestTask_Roman.Infrastructure.Services
{
    /// <summary>
    /// A base implementation of the <see cref="IDatabaseService{TEntity}"/> interface that provides common CRUD operations for database entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity managed by the service.</typeparam>
    public class DatabaseBaseService<TEntity> : IDatabaseService<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IUnitOfWork<MedicalDbContext> unitOfWork;
        private readonly IRepository<TEntity> repository;
        private readonly IEntityValidator<TEntity> validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseBaseService{TEntity}"/> class with the specified unit of work, repository, and entity validator.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used by the service.</param>
        /// <param name="repository">The repository used by the service.</param>
        /// <param name="validator">The entity validator used by the service.</param>
        public DatabaseBaseService(IUnitOfWork<MedicalDbContext> unitOfWork, IRepository<TEntity> repository, IEntityValidator<TEntity> validator)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.validator = validator;
        }

        /// <summary>
        /// Gets the unit of work used by the service.
        /// </summary>
        protected IUnitOfWork<MedicalDbContext> UnitOfWork => this.unitOfWork;

        /// <summary>
        /// Gets the repository used by the service.
        /// </summary>
        protected IRepository<TEntity> Repository => this.repository;

        /// <summary>
        /// Gets the entity validator used by the service.
        /// </summary>
        protected IEntityValidator<TEntity> Validator => this.validator;

        /// <inheritdoc/>
        public async Task<int> AddAsync(TEntity entity, CancellationToken ct = default)
        {
            this.ThrowIfNull(entity);
            this.ThrowIfInvalid(entity);

            await this.Repository.AddAsync(entity, ct)
                .ConfigureAwait(false);

            return await this.UnitOfWork.SaveAsync(ct)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            await this.Repository.DeleteAsync(id, ct)
                .ConfigureAwait(false);

            return await this.UnitOfWork.SaveAsync(ct)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<int> DeleteAsync(TEntity entity, CancellationToken ct = default)
        {
            this.ThrowIfNull(entity);
            await this.Repository.DeleteAsync(entity, ct)
                .ConfigureAwait(false);

            return await this.UnitOfWork.SaveAsync(ct)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return this.Repository.GetByIdAsync(id, ct);
        }

        /// <inheritdoc/>
        public async Task<int> UpdateAsync(TEntity entity, CancellationToken ct = default)
        {
            this.ThrowIfNull(entity);
            this.ThrowIfInvalid(entity);

            await this.Repository.UpdateAsync(entity, ct)
                .ConfigureAwait(false);

            return await this.UnitOfWork.SaveAsync(ct)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Throws a <see cref="BadRequestException"/> if the specified entity is null.
        /// </summary>
        /// <param name="entity">The entity to check for null.</param>
        protected virtual void ThrowIfNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new BadRequestException($"{nameof(entity)} can't be null");
            }
        }

        /// <summary>
        /// Throws a <see cref="ValidationException"/> with error messages if the specified entity is invalid.
        /// </summary>
        /// <param name="entity">The entity to check for validity.</param>
        protected virtual void ThrowIfInvalid(TEntity entity)
        {
            var errors = this.Validator.Validate(entity);

            if (errors.Any())
            {
                var errorMessage = string.Join("; ", errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errorMessage);
            }
        }
    }
}
