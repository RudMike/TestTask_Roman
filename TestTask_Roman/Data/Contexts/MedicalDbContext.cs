//-----------------------------------------------------------------------
// <copyright file="MedicalDbContext.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TestTask_Roman.Data.Configurations;
using TestTask_Roman.Data.Models;

namespace TestTask_Roman.Data.Contexts
{
    /// <summary>
    /// Represents the database context for the Medical application.
    /// </summary>
    public class MedicalDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        public MedicalDbContext(DbContextOptions<MedicalDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of rooms in the database.
        /// </summary>
        public DbSet<Room> Rooms { get; set; }

        /// <summary>
        /// Gets or sets the collection of areas in the database.
        /// </summary>
        public DbSet<Area> Areas { get; set; }

        /// <summary>
        /// Gets or sets the collection of doctors in the database.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Gets or sets the collection of patients in the database.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Gets or sets the collection of specializations in the database.
        /// </summary>
        public DbSet<Specialization> Specializations { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new RoomConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AreaConfiguration());
            _ = modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
            _ = modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            _ = modelBuilder.ApplyConfiguration(new PatientConfiguration());
        }
    }
}
