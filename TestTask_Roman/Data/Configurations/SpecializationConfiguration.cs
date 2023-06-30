//-----------------------------------------------------------------------
// <copyright file="SpecializationConfiguration.cs" company="RudMike">
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
    /// Configures the database schema for the <see cref="Specialization"/> entity.
    /// </summary>
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        /// <summary>
        /// Configures the database schema for the <see cref="Specialization"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            _ = builder.ToTable(DbObjectConstants.Specializations);

            _ = builder.HasKey(specialization => specialization.Id);

            _ = builder.Property(specialization => specialization.Title)
                .HasColumnName(DbObjectConstants.Title)
            .HasMaxLength(50);

            _ = builder.HasData(
                new Specialization { Id = 1, Title = "Терапевт", },
                new Specialization { Id = 2, Title = "Хирург", },
                new Specialization { Id = 3, Title = "Травматолог", },
                new Specialization { Id = 4, Title = "Отоларинголог", },
                new Specialization { Id = 5, Title = "Дерматолог", });
        }
    }
}
