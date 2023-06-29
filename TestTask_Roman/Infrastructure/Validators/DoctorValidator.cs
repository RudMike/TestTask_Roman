//-----------------------------------------------------------------------
// <copyright file="DoctorValidator.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using TestTask_Roman.Data.Configurations;
using TestTask_Roman.Data.Models;

namespace TestTask_Roman.Infrastructure.Validators
{
    /// <summary>
    /// Validates <see cref="Doctor"/> entities.
    /// </summary>
    public class DoctorValidator : IEntityValidator<Doctor>
    {
        /// <inheritdoc/>
        public IEnumerable<ValidationResult> Validate(Doctor entity)
        {
            var results = new List<ValidationResult>();

            ValidateFirstName(entity.FirstName, results);
            ValidateLastName(entity.LastName, results);
            ValidateMiddleName(entity.MiddleName, results);
            ValidateRoomId(entity.RoomId, results);
            ValidateSpecializationId(entity.SpecializationId, results);
            ValidateAreaId(entity.AreaId, results);

            return results;
        }

        private static void ValidateFirstName(string firstName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                results.Add(new ValidationResult("First name cannot be null or empty"));
            }
            else if (firstName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"First name cannot be longer than {DoctorConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateLastName(string lastName, List<ValidationResult> results)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                results.Add(new ValidationResult("Last name cannot be null or empty"));
            }
            else if (lastName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"Last name cannot be longer than {DoctorConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateMiddleName(string middleName, List<ValidationResult> results)
        {
            if (middleName.Length > DoctorConfiguration.NameMaxLength)
            {
                results.Add(new ValidationResult($"Middle name cannot be longer than {DoctorConfiguration.NameMaxLength} characters"));
            }
        }

        private static void ValidateRoomId(int? roomId, List<ValidationResult> results)
        {
            if (roomId == null || roomId <= 0)
            {
                results.Add(new ValidationResult("Room is not a valid value"));
            }
        }

        private static void ValidateSpecializationId(int? specializationId, List<ValidationResult> results)
        {
            if (specializationId == null || specializationId <= 0)
            {
                results.Add(new ValidationResult("Specialization ID is not a valid value"));
            }
        }

        private static void ValidateAreaId(int? areaId, List<ValidationResult> results)
        {
            if (areaId <= 0)
            {
                results.Add(new ValidationResult("Area is not a valid value"));
            }
        }
    }
}
