//-----------------------------------------------------------------------
// <copyright file="PatientService.cs" company="RudMike">
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
    /// Provides services for managing <see cref="Patient"/> entities.
    /// </summary>
    public class PatientService : DatabaseBaseService<Patient>, IPatientService
    {
        private readonly IPatientRepository patientRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class with the specified unit of work, repository, patient repository, and entity validator.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used by the service.</param>
        /// <param name="repository">The repository used by the service.</param>
        /// <param name="patientRepository">The patient repository used by the service.</param>
        /// <param name="validator">The entity validator used by the service.</param>
        public PatientService(IUnitOfWork<MedicalDbContext> unitOfWork, IRepository<Patient> repository, IPatientRepository patientRepository, IEntityValidator<Patient> validator)
            : base(unitOfWork, repository, validator)
        {
            this.patientRepository = patientRepository;
        }

        /// <summary>
        /// Gets the patient repository used by the service.
        /// </summary>
        protected IPatientRepository PatientRepository => this.patientRepository;

        /// <inheritdoc/>
        public Task<PagedList<PatientsResponse>> GetAllAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default)
        {
            PaginationHelper.SetDefaultIfInvalidPagination(ref page, ref pageSize);

            return this.PatientRepository
                .GetAllAsync(sortColumn, sortOrder, page, pageSize, ct);
        }
    }
}
