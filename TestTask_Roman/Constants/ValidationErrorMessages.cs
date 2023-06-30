//-----------------------------------------------------------------------
// <copyright file="ValidationErrorMessages.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TestTask_Roman.Constants
{
    /// <summary>
    /// Provides constant error messages for validation errors.
    /// </summary>
    public static class ValidationErrorMessages
    {
        /// <summary>
        /// The error message for when an address is empty.
        /// </summary>
        public const string AddressEmpty = "Address is required";

        /// <summary>
        /// The error message for when an address is too long.
        /// </summary>
        public const string AddressTooLong = "Address cannot be longer than max length: ";

        /// <summary>
        /// The error message for when a birth date is in the future.
        /// </summary>
        public const string BirthDateFromFuture = "Date of birth cannot be in the future";

        /// <summary>
        /// The error message for when a first name is null or empty.
        /// </summary>
        public const string FirstNameNullOrEmpty = "First name cannot be null or empty";

        /// <summary>
        /// The error message for when a first name is too long.
        /// </summary>
        public const string FirstNameTooLong = "First name cannot be longer than max length: ";

        /// <summary>
        /// The error message for when an area is not a valid value.
        /// </summary>
        public const string InvalidArea = "Area is not a valid value";

        /// <summary>
        /// The error message for an invalid Id parameter.
        /// </summary>
        public const string InvalidId = "Id must be positive or zero.";

        /// <summary>
        /// The error message for an invalid page parameter.
        /// </summary>
        public const string InvalidPage = "Invalid page parameter. Page must be null or greater than 0.";

        /// <summary>
        /// The error message for an invalid pageSize parameter.
        /// </summary>
        public const string InvalidPageSize = "Invalid pageSize parameter. PageSize must be null or between 1 and 200.";

        /// <summary>
        /// The error message for when a room number is not a valid value.
        /// </summary>
        public const string InvalidRoom = "Room is not a valid value";

        /// <summary>
        /// The error message for when a sex value is not a valid value.
        /// </summary>
        public const string InvalidSex = "Sex is not a valid value";

        /// <summary>
        /// The error message for an invalid sort column name.
        /// </summary>
        public const string InvalidSortColumn = "Invalid sort column name.";

        /// <summary>
        /// The error message for an invalid sort order parameter.
        /// </summary>
        public const string InvalidSortOrder = "Invalid sort order. It can be only \"asc\", \"desc\" or empty value.";

        /// <summary>
        /// The error message for when a specialization ID is not a valid value.
        /// </summary>
        public const string InvalidSpecialization = "Specialization ID is not a valid value";

        /// <summary>
        /// The error message for when a last name is null or empty.
        /// </summary>
        public const string LastNameNullOrEmpty = "Last name cannot be null or empty";

        /// <summary>
        /// The error message for when a last name is too long.
        /// </summary>
        public const string LastNameTooLong = "Last name cannot be longer than max length: ";

        /// <summary>
        /// The error message for when a middle name is too long.
        /// </summary>
        public const string MiddleNameTooLong = "Middle name cannot be longer than max length: ";
    }
}
