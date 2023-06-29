//-----------------------------------------------------------------------
// <copyright file="DoctorsResponse.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Models
{
    /// <summary>
    /// Represents a response containing information about a doctor.
    /// </summary>
    public sealed record DoctorsResponse
    {
        /// <summary>
        /// Gets the unique identifier for the doctor.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the last name of the doctor.
        /// </summary>
        public string LastName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the first name of the doctor.
        /// </summary>
        public string FirstName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the middle name of the doctor.
        /// </summary>
        public string MiddleName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the number of the room where the doctor works.
        /// </summary>
        public int Room { get; init; }

        /// <summary>
        /// Gets the specialization of the doctor.
        /// </summary>
        public string Specialization { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the area where the doctor works.
        /// </summary>
        public int? Area { get; set; }
    }
}
