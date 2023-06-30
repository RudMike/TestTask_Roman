//-----------------------------------------------------------------------
// <copyright file="DoctorRequest.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using TestTask_Roman.Constants;
using TestTask_Roman.Data.Configurations;

namespace TestTask_Roman.Models
{
    /// <summary>
    /// Represents a request with a doctor information that is sent by a controller to another component of an application.
    /// </summary>
    public sealed record DoctorRequest : IValidatableObject
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
        /// Gets the ID of the specialization of the doctor.
        /// </summary>
        public int SpecializationId { get; init; }

        /// <summary>
        /// Gets the geographic medical area where the doctor provides medical care, if applicable.
        /// </summary>
        public int? Area { get; init; }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            ValidateId(this.Id, results);
            ValidateFirstName(this.FirstName, results);
            ValidateLastName(this.LastName, results);
            ValidateMiddleName(this.MiddleName, results);
            ValidateRoom(this.Room, results);
            ValidateSpecializationId(this.SpecializationId, results);
            ValidateArea(this.Area, results);

            return results;
        }

        private static void ValidateId(int id, List<ValidationResult> results)
        {
            if (id < 0)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.IdLessZero));
            }
        }

        private static void ValidateFirstName(string firstName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                results.Add(new ValidationResult(ValidationErrorMessages.FirstNameNullOrEmpty));
            }
            else if (firstName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.FirstNameTooLong + DoctorConfiguration.NameMaxLength));
            }
        }

        private static void ValidateLastName(string lastName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                results.Add(new ValidationResult(ValidationErrorMessages.LastNameNullOrEmpty));
            }
            else if (lastName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.LastNameTooLong + DoctorConfiguration.NameMaxLength));
            }
        }

        private static void ValidateMiddleName(string middleName, List<ValidationResult> results)
        {
            if (middleName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.MiddleNameTooLong + DoctorConfiguration.NameMaxLength));
            }
        }

        private static void ValidateRoom(int roomId, List<ValidationResult> results)
        {
            if (roomId <= 0)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.InvalidRoom));
            }
        }

        private static void ValidateSpecializationId(int? specializationId, List<ValidationResult> results)
        {
            if (specializationId == null || specializationId <= 0)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.InvalidSpecialization));
            }
        }

        private static void ValidateArea(int? areaId, List<ValidationResult> results)
        {
            if (areaId <= 0)
            {
                results.Add(new ValidationResult(ValidationErrorMessages.InvalidArea));
            }
        }
    }
}
