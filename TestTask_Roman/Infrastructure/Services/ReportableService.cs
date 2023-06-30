//-----------------------------------------------------------------------
// <copyright file="ReportableService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Constants;
using TestTask_Roman.Data;
using TestTask_Roman.Data.Contexts;
using TestTask_Roman.Data.Repositories;
using TestTask_Roman.Domain;
using TestTask_Roman.Infrastructure.Mapping;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Infrastructure.Services
{
    /// <summary>
    /// Provides a base implementation of a service that can interact with a database and generate reports.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the service operates on.</typeparam>
    /// <typeparam name="TReport">The type of report that the service generates.</typeparam>
    /// <typeparam name="TRequest">The type of DTOs that are used to create, update, and delete entities.</typeparam>
    public class ReportableService<TEntity, TReport, TRequest> : BaseService<TEntity, TRequest>, IReportService<TEntity, TReport, TRequest>
        where TEntity : class, IEntity
    {
        private readonly IReportRepository<TReport> reportRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportableService{TEntity,TReport,TRequest}"/> class with the specified dependencies.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to interact with the database.</param>
        /// <param name="repository">The repository used to interact with the entity type.</param>
        /// <param name="reportRepository">The repository used to generate reports.</param>
        /// <param name="mapper">The mapper used to map between DTOs and entities.</param>
        public ReportableService(IUnitOfWork<MedicalDbContext> unitOfWork, IRepository<TEntity> repository, IReportRepository<TReport> reportRepository, IMapper<TRequest, TEntity> mapper)
            : base(unitOfWork, repository, mapper)
        {
            this.reportRepository = reportRepository;
        }

        /// <inheritdoc/>
        /// <remarks>Default values for the pagination uses from <see cref="RoutingConstants"/> type.</remarks>
        public Task<PagedList<TReport>> GetReportAsync(string? sortColumn, string? sortOrder, int? page, int? pageSize, CancellationToken ct = default)
        {
            SetDefaultIfInvalidPagination(ref page, ref pageSize);

            return this.reportRepository.GetReportAsync(sortColumn, sortOrder, (int)page!, (int)pageSize!, ct);
        }

        private static void SetDefaultIfInvalidPagination(ref int? page, ref int? pageSize)
        {
            if (page == null || page < 1)
            {
                page = RoutingConstants.PageDefault;
            }

            if (pageSize == null || pageSize < 1)
            {
                pageSize = RoutingConstants.PageSizeDefault;
            }
        }
    }
}
