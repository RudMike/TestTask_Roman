//-----------------------------------------------------------------------
// <copyright file="PatientValidator.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using TestTask_Roman.Data.Configurations;
using TestTask_Roman.Data.Enums;
using TestTask_Roman.Data.Models;

namespace TestTask_Roman.Infrastructure.Validators
{
    /// <summary>
    /// Validates <see cref="Patient"/> entities.
    /// </summary>
    public class PatientValidator : IEntityValidator<Patient>
    {
        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(Patient entity)
        {
            var results = new List<ValidationResult>();

            ValidateFirstName(entity.FirstName, results);
            ValidateLastName(entity.LastName, results);
            ValidateMiddleName(entity.MiddleName, results);
            ValidateAddress(entity.Address, results);
            ValidateBirthDate(entity.BirthDate, results);
            ValidateAreaId(entity.AreaId, results);
            ValidateSex(entity.Sex, results);

            return results;
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

        private static void ValidateAreaId(int? areaId, List<ValidationResult> results)
        {
            if (areaId == null || areaId <= 0)
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
