//-----------------------------------------------------------------------
// <copyright file="IEntityValidator.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace TestTask_Roman.Infrastructure.Validators
{
    /// <summary>
    /// Represents a validator for a specific entity type.
    /// </summary>
    /// <typeparam name="T">The type of entity to validate.</typeparam>
    public interface IEntityValidator<T>
        where T : class
    {
        /// <summary>
        /// Validates the specified entity and returns a collection of validation results.
        /// </summary>
        /// <param name="entity">The entity to validate.</param>
        /// <returns>A collection of validation results.</returns>
        public IEnumerable<ValidationResult> Validate(T entity);
    }
}
