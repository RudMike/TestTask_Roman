//-----------------------------------------------------------------------
// <copyright file="PatientRequest.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using TestTask_Roman.Data.Configurations;
using TestTask_Roman.Data.Enums;

namespace TestTask_Roman.Models
{
    /// <summary>
    /// Represents a request with a patient information that is sent by a controller to another component of an application.
    /// </summary>
    public sealed record PatientRequest : IValidatableObject
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
        public DateOnly BirthDate { get; init; }

        /// <summary>
        /// Gets the sex of the patient.
        /// </summary>
        public Sex Sex { get; init; }

        /// <summary>
        /// Gets the area number where the patient lives.
        /// </summary>
        public int Area { get; init; }

        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            ValidateId(this.Id, results);
            ValidateFirstName(this.FirstName, results);
            ValidateLastName(this.LastName, results);
            ValidateMiddleName(this.MiddleName, results);
            ValidateAddress(this.Address, results);
            ValidateBirthDate(this.BirthDate, results);
            ValidateArea(this.Area, results);
            ValidateSex(this.Sex, results);

            return results;
        }

        private static void ValidateId(int id, List<ValidationResult> results)
        {
            if (id < 0)
            {
                results.Add(new ValidationResult("Id cannot be less zero"));
            }
        }

        private static void ValidateFirstName(string firstName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                results.Add(new ValidationResult("First name cannot be null or empty"));
            }
            else if (firstName.Length > PatientConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"First name cannot be longer than {PatientConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateLastName(string lastName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                results.Add(new ValidationResult("Last name cannot be null or empty"));
            }
            else if (lastName.Length > PatientConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"Last name cannot be longer than {PatientConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateMiddleName(string middleName, List<ValidationResult> results)
        {
            if (middleName.Length > PatientConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"Middle name cannot be longer than {PatientConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateAddress(string address, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(address))
            {
                results.Add(new ValidationResult("Address is required"));
            }
            else if (address.Length > PatientConfiguration.AddressMaxLength)
            {
                results.Add(new ValidationResult($"Address cannot be longer than {PatientConfiguration.AddressMaxLength} characters"));
            }
        }

        private static void ValidateBirthDate(DateOnly birthDate, List<ValidationResult> results)
        {
            if (birthDate > DateOnly.FromDateTime(DateTime.Now))
            {
                results.Add(new ValidationResult("Date of birth cannot be in the future"));
            }
        }

        private static void ValidateArea(int area, List<ValidationResult> results)
        {
            if (area <= 0)
            {
                results.Add(new ValidationResult("Area is not a valid value"));
            }
        }

        private static void ValidateSex(Sex sex, List<ValidationResult> results)
        {
            if (!Enum.IsDefined(typeof(Sex), sex))
            {
                results.Add(new ValidationResult("Sex is not a valid value"));
            }
        }
    }
}
