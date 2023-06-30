//-----------------------------------------------------------------------
// <copyright file="BaseService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data;
using TestTask_Roman.Data.Contexts;
using TestTask_Roman.Data.Repositories;
using TestTask_Roman.Domain;
using TestTask_Roman.Infrastructure.Exceptions;
using TestTask_Roman.Infrastructure.Mapping;

namespace TestTask_Roman.Infrastructure.Services
{
    /// <summary>
    /// A base implementation of the <see cref="IBaseService{TEntity, TRequest}"/> interface that provides common CRUD operations for database entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity managed by the service.</typeparam>
    /// <typeparam name="TRequest">The type of DTOs that are used to create, update, and delete entities.</typeparam>
    public class BaseService<TEntity, TRequest> : IBaseService<TEntity, TRequest>
        where TEntity : class, IEntity
    {
        private readonly IUnitOfWork<MedicalDbContext> unitOfWork;
        private readonly IRepository<TEntity> repository;
        private readonly IMapper<TRequest, TEntity> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, TRequest}"/> class with the specified unit of work, repository, and entity validator.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used by the service.</param>
        /// <param name="repository">The repository used by the service.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public BaseService(IUnitOfWork<MedicalDbContext> unitOfWork, IRepository<TEntity> repository, IMapper<TRequest, TEntity> mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the unit of work used by the service.
        /// </summary>
        protected IUnitOfWork<MedicalDbContext> UnitOfWork => this.unitOfWork;

        /// <summary>
        /// Gets the repository used by the service.
        /// </summary>
        protected IRepository<TEntity> Repository => this.repository;

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TRequest request, CancellationToken ct = default)
        {
            ThrowIfNull(request);

            var entity = this.mapper.Map(request);

            await this.Repository.AddAsync(entity, ct)
                .ConfigureAwait(false);

            await this.UnitOfWork.SaveAsync(ct)
                .ConfigureAwait(false);

            return entity;
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
        public async Task<int> DeleteAsync(TRequest request, CancellationToken ct = default)
        {
            ThrowIfNull(request);

            var entity = this.mapper.Map(request);

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
        public async Task<TEntity> UpdateAsync(TRequest request, CancellationToken ct = default)
        {
            ThrowIfNull(request);

            var entity = this.mapper.Map(request);

            await this.Repository.UpdateAsync(entity, ct)
                .ConfigureAwait(false);

            await this.UnitOfWork.SaveAsync(ct)
               .ConfigureAwait(false);

            return entity;
        }

        private static void ThrowIfNull(TRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException($"{nameof(request)} can't be null");
            }
        }
    }
}
