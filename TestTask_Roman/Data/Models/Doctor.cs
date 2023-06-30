//-----------------------------------------------------------------------
// <copyright file="Doctor.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace TestTask_Roman.Data.Models
{
    /// <summary>
    /// Represents a doctor in the system.
    /// </summary>
    public class Doctor : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the doctor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name of the doctor.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the doctor.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the middle name of the doctor.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the number of the room where the doctor works.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key that links the <see cref="Doctor"/> entity to the <see cref="Models.Room"/> entity.
        /// </remarks>
        public int? RoomId { get; set; }

        /// <summary>
        /// Gets or sets the room where the doctor practices.
        /// </summary>
        /// <remarks>
        /// This is a navigation property that represents the relationship between the <see cref="Doctor"/> and <see cref="Models.Room"/> entities.
        /// </remarks>
        [JsonIgnore]
        public Room Room { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ID of the specialization of the doctor.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key that links the <see cref="Doctor"/> entity to the <see cref="Models.Specialization"/> entity.
        /// </remarks>
        public int? SpecializationId { get; set; }

        /// <summary>
        /// Gets or sets the specialization of the doctor.
        /// </summary>
        /// <remarks>
        /// This is a navigation property that represents the relationship between the <see cref="Doctor"/> and <see cref="Models.Specialization"/> entities.
        /// </remarks>
        [JsonIgnore]
        public Specialization Specialization { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ID of the geographic medical area where the doctor provides medical care, if applicable.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key that links the <see cref="Doctor"/> entity to the <see cref="Models.Area"/> entity.
        /// </remarks>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or sets the geographic medical area where the doctor provides medical care, if applicable.
        /// </summary>
        /// <remarks>
        /// This is a navigation property that represents the relationship between the <see cref="Doctor"/> and <see cref="Models.Area"/> entities.
        /// This property is nullable because not all doctors are associated with a specific geographic area.
        /// </remarks>
        [JsonIgnore]
        public Area? Area { get; set; }
    }
}
