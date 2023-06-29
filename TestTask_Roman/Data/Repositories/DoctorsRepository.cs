//-----------------------------------------------------------------------
// <copyright file="DoctorsRepository.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestTask_Roman.Constants;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Infrastructure;
using TestTask_Roman.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Data.Repositories
{
    /// <summary>
    /// Represents a repository for managing <see cref="Doctor"/> entities.
    /// </summary>
    public class DoctorsRepository : BaseRepository<Doctor>, IReportRepository<DoctorsResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorsRepository"/> class with the specified database context factory.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory to use for creating database contexts.</param>
        public DoctorsRepository(DbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {
        }

        /// <inheritdoc/>
        public Task<PagedList<DoctorsResponse>> GetReportAsync(string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken ct = default)
        {
            var query = this.DbSet.AsQueryable();
            var keySelector = GetSortProperty(sortColumn);
            query = SortHelper<Doctor>.ApplySort(query, keySelector, sortOrder);

            var doctorsResponcesQuery = query
                .Include(doctor => doctor.Specialization)
                .Select(doctor => new DoctorsResponse
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    MiddleName = doctor.MiddleName,
                    Room = doctor.RoomId ?? 0,
                    Specialization = doctor.Specialization.Title,
                    Area = doctor.AreaId,
                });

            return PagedList<DoctorsResponse>.CreateAsync(doctorsResponcesQuery, page, pageSize, ct);
        }

        private static Expression<Func<Doctor, object>> GetSortProperty(string? sortColumn)
        {
            Expression<Func<Doctor, object>> keySelector = sortColumn?.ToLower() switch
            {
                RoutingConstants.FirstName => doctor => doctor.FirstName,
                RoutingConstants.LastName => doctor => doctor.LastName,
                RoutingConstants.MiddleName => doctor => doctor.MiddleName,
                RoutingConstants.Room => doctor => doctor.RoomId!,
                RoutingConstants.Specialization => doctor => doctor.Specialization,
                RoutingConstants.Area => doctor => doctor.AreaId!,
                _ => doctor => doctor.Id,
            };

            return keySelector;
        }
    }
}
