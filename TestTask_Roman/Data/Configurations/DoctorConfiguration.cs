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

            _ = builder.HasData(
                new Doctor
                {
                    Id = 1,
                    LastName = "Иванов",
                    FirstName = "Игорь",
                    MiddleName = "Александрович",
                    RoomId = 10,
                    SpecializationId = 1,
                    AreaId = 100,
                },
                new Doctor
                {
                    Id = 2,
                    LastName = "Петров",
                    FirstName = "Дмитрий",
                    MiddleName = "Сергеевич",
                    RoomId = 12,
                    SpecializationId = 2,
                    AreaId = 200,
                },
                new Doctor
                {
                    Id = 3,
                    LastName = "Сидорова",
                    FirstName = "Елена",
                    MiddleName = "Ивановна",
                    RoomId = 13,
                    SpecializationId = 3,
                    AreaId = 300,
                },
                new Doctor
                {
                    Id = 4,
                    LastName = "Кузнецов",
                    FirstName = "Андрей",
                    MiddleName = "Петрович",
                    RoomId = 14,
                    SpecializationId = 4,
                    AreaId = 400,
                },
                new Doctor
                {
                    Id = 5,
                    LastName = "Николаева",
                    FirstName = "Ольга",
                    MiddleName = "Алексеевна",
                    RoomId = 15,
                    SpecializationId = 5,
                    AreaId = 500,
                },
                new Doctor
                {
                    Id = 6,
                    LastName = "Смирнов",
                    FirstName = "Алексей",
                    MiddleName = "Дмитриевич",
                    RoomId = 11,
                    SpecializationId = 2,
                    AreaId = 100,
                },
                new Doctor
                {
                    Id = 7,
                    LastName = "Волкова",
                    FirstName = "Марина",
                    MiddleName = "Сергеевна",
                    RoomId = 12,
                    SpecializationId = 3,
                    AreaId = 200,
                },
                new Doctor
                {
                    Id = 8,
                    LastName = "Козлов",
                    FirstName = "Николай",
                    MiddleName = "Андреевич",
                    RoomId = 13,
                    SpecializationId = 4,
                    AreaId = 300,
                },
                new Doctor
                {
                    Id = 9,
                    LastName = "Морозова",
                    FirstName = "Екатерина",
                    MiddleName = "Владимировна",
                    RoomId = 14,
                    SpecializationId = 5,
                },
                new Doctor
                {
                    Id = 10,
                    LastName = "Павлов",
                    FirstName = "Илья",
                    MiddleName = "Геннадьевич",
                    RoomId = 15,
                    SpecializationId = 1,
                });
        }
    }
}
