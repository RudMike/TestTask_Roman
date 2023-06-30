//-----------------------------------------------------------------------
// <copyright file="RoomConfiguration.cs" company="RudMike">
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
    /// Configures the database schema for the <see cref="Room"/> entity.
    /// </summary>
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        /// <summary>
        /// Configures the database schema for the <see cref="Room"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            _ = builder.ToTable(DbObjectConstants.Rooms);

            _ = builder.HasKey(room => room.Id);

            _ = builder.Property(room => room.Id)
                .HasColumnName(DbObjectConstants.RoomId)
            .ValueGeneratedNever();

            _ = builder.HasData(
                new Room { Id = 10, },
                new Room { Id = 11, },
                new Room { Id = 12, },
                new Room { Id = 13, },
                new Room { Id = 14, },
                new Room { Id = 15, });
        }
    }
}
