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
                .HasMaxLength(NameMaxLength)
                .IsRequired(false);

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
                                   .First(sex => string.Equals(sex.GetDescription(), stringValue, StringComparison.OrdinalIgnoreCase)));

            _ = builder.Property(patient => patient.Sex)
                .HasColumnName(DbObjectConstants.Sex)
                .HasMaxLength(5)
                .HasConversion(sexConverter);

            _ = builder.Property(patient => patient.AreaId)
                .HasColumnName(DbObjectConstants.Area);

            _ = builder.HasData(
                new Patient
                {
                    Id = 1,
                    LastName = "Иванов",
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    Address = "ул. Пушкина, д. 10",
                    BirthDate = new DateOnly(1980, 1, 1),
                    Sex = Sex.Male,
                    AreaId = 100,
                },
                new Patient
                {
                    Id = 2,
                    LastName = "Петрова",
                    FirstName = "Мария",
                    MiddleName = "Алексеевна",
                    Address = "ул. Лермонтова, д. 5",
                    BirthDate = new DateOnly(1990, 2, 2),
                    Sex = Sex.Female,
                    AreaId = 200,
                },
                new Patient
                {
                    Id = 3,
                    LastName = "Сидоров",
                    FirstName = "Алексей",
                    MiddleName = "Петрович",
                    Address = "ул. Гоголя, д. 15",
                    BirthDate = new DateOnly(1975, 3, 3),
                    Sex = Sex.Male,
                    AreaId = 300,
                },
                new Patient
                {
                    Id = 4,
                    LastName = "Кузнецова",
                    FirstName = "Елена",
                    MiddleName = "Сергеевна",
                    Address = "ул. Тургенева, д. 20",
                    BirthDate = new DateOnly(1985, 4, 4),
                    Sex = Sex.Female,
                    AreaId = 400,
                },
                new Patient
                {
                    Id = 5,
                    LastName = "Николаев",
                    FirstName = "Игорь",
                    MiddleName = "Александрович",
                    Address = "ул. Чехова, д. 25",
                    BirthDate = new DateOnly(1995, 5, 5),
                    Sex = Sex.Male,
                    AreaId = 500,
                },
                new Patient
                {
                    Id = 6,
                    LastName = "Смирнова",
                    FirstName = "Анна",
                    MiddleName = "Андреевна",
                    Address = "ул. Достоевского, д. 30",
                    BirthDate = new DateOnly(1984, 6, 6),
                    Sex = Sex.Female,
                    AreaId = 100,
                },
                new Patient
                {
                    Id = 7,
                    LastName = "Волков",
                    FirstName = "Сергей",
                    MiddleName = "Николаевич",
                    Address = "ул. Пастернака, д. 35",
                    BirthDate = new DateOnly(1979, 7, 7),
                    Sex = Sex.Male,
                    AreaId = 200,
                },
                new Patient
                {
                    Id = 8,
                    LastName = "Козлова",
                    FirstName = "Ольга",
                    MiddleName = "Викторовна",
                    Address = "ул. Есенина, д. 40",
                    BirthDate = new DateOnly(1991, 8, 8),
                    Sex = Sex.Female,
                    AreaId = 300,
                },
                new Patient
                {
                    Id = 9,
                    LastName = "Морозов",
                    FirstName = "Дмитрий",
                    MiddleName = "Игоревич",
                    Address = "ул. Шолохова, д. 45",
                    BirthDate = new DateOnly(1981, 9, 9),
                    Sex = Sex.Male,
                    AreaId = 400,
                },
                new Patient
                {
                    Id = 10,
                    LastName = "Андреева",
                    FirstName = "Екатерина",
                    MiddleName = "Дмитриевна",
                    Address = "ул. Ломоносова, д. 50",
                    BirthDate = new DateOnly(1992, 10, 10),
                    Sex = Sex.Female,
                    AreaId = 500,
                });
        }
    }
}
