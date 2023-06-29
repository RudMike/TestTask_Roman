//-----------------------------------------------------------------------
// <copyright file="PatientConfiguration.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask_Roman.Data.Enums;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Utilities;

namespace TestTask_Roman.Data.Configurations
{
    /// <summary>
    /// Configures the database schema for the <see cref="Patient"/> entity.
    /// </summary>
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        /// <summary>
        /// The maximum length of a name property for the <see cref="Patient"/> entity.
        /// </summary>
        public const int NameMaxLength = 30;

        /// <summary>
        /// The maximum length of the address property for the <see cref="Patient"/> entity.
        /// </summary>
        public const int AddressMaxLength = 100;

        /// <summary>
        /// Configures the database schema for the <see cref="Patient"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            _ = builder.ToTable(DbObjectConstants.Patients);

            _ = builder.HasKey(patient => patient.Id);

            _ = builder.HasOne(patient => patient.Area)
                .WithMany()
                .HasForeignKey(patient => patient.AreaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            _ = builder.Property(patient => patient.LastName)
                .HasColumnName(DbObjectConstants.LastName)
                .HasMaxLength(NameMaxLength);

            _ = builder.Property(patient => patient.FirstName)
                .HasColumnName(DbObjectConstants.FirstName)
                .HasMaxLength(NameMaxLength);

            _ = builder.Property(patient => patient.MiddleName)
                .HasColumnName(DbObjectConstants.MiddleName)
                .HasMaxLength(NameMaxLength);

            _ = builder.Property(patient => patient.Address)
                .HasColumnName(DbObjectConstants.Address)
                .HasMaxLength(AddressMaxLength);

            var dateConverter = new ValueConverter<DateOnly, DateTime>(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(DateTime.Now));

            _ = builder.Property(patient => patient.BirthDate)
                .HasColumnName(DbObjectConstants.BirthDate)
                .HasConversion(dateConverter)
                .HasPrecision(0);

            var sexConverter = new ValueConverter<Sex, string>(
                enumValue => enumValue.GetDescription(),
                stringValue => Enum.GetValues(typeof(Sex))
                                   .Cast<Sex>()
                                   .First(sex => string.Compare(sex.GetDescription(), stringValue, StringComparison.OrdinalIgnoreCase) == 0));

            _ = builder.Property(patient => patient.Sex)
                .HasColumnName(DbObjectConstants.Sex)
                .HasMaxLength(5)
                .HasConversion(sexConverter);

            _ = builder.Property(patient => patient.AreaId)
                .HasColumnName(DbObjectConstants.Area);
        }
    }
}
