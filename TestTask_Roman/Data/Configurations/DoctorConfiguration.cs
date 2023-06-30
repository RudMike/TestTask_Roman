//-----------------------------------------------------------------------
// <copyright file="DoctorConfiguration.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask_Roman.Data.Models;

namespace TestTask_Roman.Data.Configurations
{
    /// <summary>
    /// Configures the database schema for the <see cref="Doctor"/> entity.
    /// </summary>
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        /// <summary>
        /// The maximum length of a name property for the <see cref="Doctor"/> entity.
        /// </summary>
        public const int NameMaxLength = 30;

        /// <summary>
        /// Configures the database schema for the <see cref="Doctor"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            _ = builder.ToTable(DbObjectConstants.Doctors);

            _ = builder.HasKey(doctor => doctor.Id);

            _ = builder.HasOne(doctor => doctor.Room)
                .WithMany()
                .HasForeignKey(doctor => doctor.RoomId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            _ = builder.HasOne(doctor => doctor.Specialization)
                .WithMany()
                .HasForeignKey(doctor => doctor.SpecializationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            _ = builder.HasOne(doctor => doctor.Area)
                .WithMany()
                .HasForeignKey(doctor => doctor.AreaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            _ = builder.Property(doctor => doctor.LastName)
                .HasColumnName(DbObjectConstants.LastName)
                .HasMaxLength(NameMaxLength);

            _ = builder.Property(doctor => doctor.FirstName)
                .HasColumnName(DbObjectConstants.FirstName)
                .HasMaxLength(NameMaxLength);

            _ = builder.Property(doctor => doctor.MiddleName)
                .HasColumnName(DbObjectConstants.MiddleName)
                .HasMaxLength(NameMaxLength)
                .IsRequired(false);

            _ = builder.Property(doctor => doctor.RoomId)
                .HasColumnName(DbObjectConstants.Room);

            _ = builder.Property(doctor => doctor.SpecializationId)
                .HasColumnName(DbObjectConstants.Specialization);

            _ = builder.Property(doctor => doctor.AreaId)
                .HasColumnName(DbObjectConstants.Area);
        }
    }
}
