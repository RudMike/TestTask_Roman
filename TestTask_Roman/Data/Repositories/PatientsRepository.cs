//-----------------------------------------------------------------------
// <copyright file="PatientsRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using TestTask_Roman.Constants;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Infrastructure;
using TestTask_Roman.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Represents a repository for managing <see cref="Patient"/> entities.
    /// </summary>
    public class PatientsRepository : BaseRepository<Patient>, IReportRepository<PatientsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsRepository"/> class with the specified database context factory.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory to use for creating database contexts.</param>
        public PatientsRepository(DbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        /// <inheritdoc/>
        public Task<PagedList<PatientsResponse>> GetReportAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default)
        {
            var query = this.DbSet.AsQueryable();
            var keySelector = GetSortProperty(sortColumn);

            query = SortHelper<Patient>.ApplySort(query, keySelector, sortOrder);

            var patientsResponcesQuery = query
                .Select(patient => new PatientsResponse
                {
                    Id = patient.Id,
                    Address = patient.Address,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    MiddleName = patient.MiddleName!,
                    BirthDate = patient.BirthDate,
                    Sex = patient.Sex.GetDescription(),
                    Area = patient.AreaId ?? 0,
                });

            return PagedList<PatientsResponse>.CreateAsync(patientsResponcesQuery, page, pageSize, ct);
        }

        private static Expression<Func<Patient, object>> GetSortProperty(string? sortColumn)
        {
            Expression<Func<Patient, object>> keySelector = sortColumn?.ToLower() switch
            {
                RoutingConstants.FirstName => patient => patient.FirstName,
                RoutingConstants.LastName => patient => patient.LastName,
                RoutingConstants.MiddleName => patient => patient.MiddleName!,
                RoutingConstants.BirthDate => patient => patient.BirthDate,
                RoutingConstants.Area => patient => patient.AreaId!,
                RoutingConstants.Address => patient => patient.Address,
                RoutingConstants.Sex => patient => patient.Sex,
                _ => patient => patient.Id,
            };

            return keySelector;
        }
    }
}
