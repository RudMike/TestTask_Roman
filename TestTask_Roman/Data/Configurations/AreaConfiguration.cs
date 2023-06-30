//-----------------------------------------------------------------------
// <copyright file="AreaConfiguration.cs" company="RudMike">
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
    /// Configures the database schema for the <see cref="Area"/> entity.
    /// </summary>
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        /// <summary>
        /// Configures the database schema for the <see cref="Area"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            _ = builder.ToTable(DbObjectConstants.Areas);

            _ = builder.HasKey(area => area.Id);

            _ = builder.Property(area => area.Id)
                .HasColumnName(DbObjectConstants.AreaId)
                .ValueGeneratedNever();

            _ = builder.HasData(
                new Area { Id = 100, },
                new Area { Id = 200, },
                new Area { Id = 300, },
                new Area { Id = 400, },
                new Area { Id = 500, },
                new Area { Id = 600, });
        }
    }
}
