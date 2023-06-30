//-----------------------------------------------------------------------
// <copyright file="Patient.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text.Json.Serialization;
using TestTask_Roman.Data.Enums;

namespace TestTask_Roman.Data.Models
{
    /// <summary>
    /// Represents a patient in the system.
    /// </summary>
    public class Patient : IEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name of the patient.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the patient.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the middle name of the patient.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the address of the patient.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the birth date of the patient.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the sex of the patient.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets the area number where the patient lives.
        /// </summary>
        /// <remarks>
        /// This property represents the foreign key that links the <see cref="Patient"/> entity to the <see cref="Models.Area"/> entity.
        /// </remarks>
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or sets the area where the patient lives.
        /// </summary>
        /// <remarks>
        /// This is a navigation property that represents the relationship between the <see cref="Patient"/> and <see cref="Models.Area"/> entities.
        /// </remarks>
        [JsonIgnore]
        public Area Area { get; set; } = null!;
    }
}
