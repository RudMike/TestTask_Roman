//-----------------------------------------------------------------------
// <copyright file="ControllerRequestBaseValidator.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestTask_Roman.Constants;

namespace TestTask_Roman.Validators
{
    /// <summary>
    /// Provides a base class for validating controller request objects.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object to validate.</typeparam>
    public abstract class ControllerRequestBaseValidator<TRequest>
        where TRequest : class
    {
        /// <summary>
        /// Validates the specified request object and model state.
        /// </summary>
        /// <param name="request">The request object to validate.</param>
        /// <param name="modelState">The model state containing the validation errors.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if the request is valid.</returns>
        public virtual ActionResult? ValidateRequest(TRequest request, ModelStateDictionary modelState)
        {
            if (request == null)
            {
                return new UnprocessableEntityResult();
            }

            if (!modelState.IsValid)
            {
                return this.BadRequestResponse(modelState);
            }

            return null;
        }

        /// <summary>
        /// Validates the specified ID parameter.
        /// </summary>
        /// <param name="id">The ID parameter to validate.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if the ID is valid.</returns>
        public virtual ActionResult? ValidateId(int id)
        {
            if (id >= 0)
            {
                return null;
            }

            return new BadRequestObjectResult(ValidationErrorMessages.InvalidId);
        }

        /// <summary>
        /// Validates the specified sort column, sort order, page, and page size parameters.
        /// </summary>
        /// <param name="sortColumn">The sort column name to validate.</param>
        /// <param name="sortOrder">The sort order to validate.</param>
        /// <param name="page">The page number to validate.</param>
        /// <param name="pageSize">The page size to validate.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if all parameters are valid.</returns>
        public virtual ActionResult? ValidateRequest(string? sortColumn, string? sortOrder, int? page, int? pageSize)
        {
            var columnValidationResult = this.ValidateColumnName(sortColumn);

            if (columnValidationResult != null)
            {
                return columnValidationResult;
            }

            var orderValidationResult = this.ValidateSortOrder(sortOrder);

            if (orderValidationResult != null)
            {
                return orderValidationResult;
            }

            var pagesValidationResult = this.ValidatePages(page, pageSize);

            if (pagesValidationResult != null)
            {
                return pagesValidationResult;
            }

            return null;
        }

        /// <summary>
        /// Creates a bad request response with the specified model state errors.
        /// </summary>
        /// <param name="modelState">The model state containing the validation errors.</param>
        /// <returns>A bad request response containing the validation errors.</returns>
        protected virtual BadRequestObjectResult BadRequestResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(
                                                    value => value.Errors,
                                                    (value, error) => error.ErrorMessage);

            return new BadRequestObjectResult(new { Errors = errors });
        }

        /// <summary>
        /// Validates the specified sort order.
        /// </summary>
        /// <param name="sortOrder">The sort order to validate.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if the sort order is valid.</returns>
        protected virtual ActionResult? ValidateSortOrder(string? sortOrder)
        {
            if (string.IsNullOrEmpty(sortOrder))
            {
                return null;
            }

            if (!this.IsEqualIgnoreCase(sortOrder, RoutingConstants.ByAscending) &&
                !this.IsEqualIgnoreCase(sortOrder, RoutingConstants.ByDescending))
            {
                return new BadRequestObjectResult(ValidationErrorMessages.InvalidSortOrder);
            }

            return null;
        }

        /// <summary>
        /// Validates the specified page and page size parameters.
        /// </summary>
        /// <param name="page">The page number to validate.</param>
        /// <param name="pageSize">The page size to validate.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if the page and page size are valid.</returns>
        protected virtual ActionResult? ValidatePages(int? page, int? pageSize)
        {
            if (page != null && page < 1)
            {
                return new BadRequestObjectResult(ValidationErrorMessages.InvalidPage);
            }

            if (pageSize != null && (pageSize < 1 || pageSize > 200))
            {
                return new BadRequestObjectResult(ValidationErrorMessages.InvalidPageSize);
            }

            return null;
        }

        /// <summary>
        /// Compares two strings for equality, ignoring case.
        /// </summary>
        /// <param name="value1">The first string to compare.</param>
        /// <param name="value2">The second string to compare.</param>
        /// <returns><see langword="true"/> if the strings are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
        protected bool IsEqualIgnoreCase(string? value1, string? value2)
        {
            return string.Compare(value1, value2, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        /// Validates the specified sort column name.
        /// </summary>
        /// <param name="sortColumn">The sort column name to validate.</param>
        /// <returns>An action result indicating any validation errors, or <see langword="null"/> if the sort column name is valid.</returns>
        protected abstract ActionResult? ValidateColumnName(string? sortColumn);
    }
}
