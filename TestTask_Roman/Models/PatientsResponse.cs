//-----------------------------------------------------------------------
// <copyright file="PatientsResponse.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Models
{
    /// <summary>
    /// Represents a response containing information about a patient.
    /// </summary>
    public sealed record PatientsResponse
    {
        /// <summary>
        /// Gets the unique identifier for the patient.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the last name of the patient.
        /// </summary>
        public string LastName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the first name of the patient.
        /// </summary>
        public string FirstName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the middle name of the patient.
        /// </summary>
        public string MiddleName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the address of the patient.
        /// </summary>
        public string Address { get; init; } = string.Empty;

        /// <summary>
        /// Gets the birth date of the patient.
        /// </summary>
        public DateTime BirthDate { get; init; }

        /// <summary>
        /// Gets the sex of the patient.
        /// </summary>
        public string Sex { get; init; } = string.Empty;

        /// <summary>
        /// Gets the area of the patient.
        /// </summary>
        public int Area { get; init; }
    }
}
