//-----------------------------------------------------------------------
// <copyright file="Specialization.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Data.Models
{
    /// <summary>
    /// Represents a medical specialization of a doctor.
    /// </summary>
    public class Specialization
    {
        /// <summary>
        /// Gets or sets the unique identifier for the specialization.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the specialization.
        /// </summary>
        public string Title { get; set; } = string.Empty;
    }
}
