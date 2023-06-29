//-----------------------------------------------------------------------
// <copyright file="DoctorService.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Contexts;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Data.Repositories;
using TestTask_Roman.Domain;
using TestTask_Roman.Infrastructure.Validators;
using TestTask_Roman.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Infrastructure.Services
{
    /// <summary>
    /// Provides services for managing <see cref="Doctor"/> entities.
    /// </summary>
    public class DoctorService : DbBaseService<Doctor>, IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorService"/> class with the specified unit of work, repository, doctor repository, and entity validator.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used by the service.</param>
        /// <param name="repository">The repository used by the service.</param>
        /// <param name="doctorRepository">The doctor repository used by the service.</param>
        /// <param name="validator">The entity validator used by the service.</param>
        public DoctorService(IUnitOfWork<MedicalDbContext> unitOfWork, IRepository<Doctor> repository, IDoctorRepository doctorRepository, IEntityValidator<Doctor> validator)
            : base(unitOfWork, repository, validator)
        {
            this.doctorRepository = doctorRepository;
        }

        /// <summary>
        /// Gets the doctor repository used by the service.
        /// </summary>
        protected IDoctorRepository DoctorRepository => this.doctorRepository;

        /// <inheritdoc/>
        public Task<PagedList<DoctorsResponse>> GetAllAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default)
        {
            PaginationHelper.SetDefaultIfInvalidPagination(ref page, ref pageSize);

            return this.DoctorRepository
                .GetAllAsync(sortColumn, sortOrder, page, pageSize, ct);
        }
    }
}
