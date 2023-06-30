//-----------------------------------------------------------------------
// <copyright file="DoctorRequestValidator.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using TestTask_Roman.Constants;
using TestTask_Roman.Models;

namespace TestTask_Roman.Validators
{
    /// <summary>
    /// Provides validation tools for doctor controller requests.
    /// </summary>
    public class DoctorRequestValidator : BaseRequestValidator<DoctorRequest>
    {
        /// <inheritdoc/>
        protected override ActionResult? ValidateColumnName(string? sortColumn)
        {
            if (string.IsNullOrEmpty(sortColumn))
            {
                return null;
            }

            if (!this.IsEqualIgnoreCase(sortColumn, RoutingConstants.Id) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.LastName) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.FirstName) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.MiddleName) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.Room) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.Specialization) &&
                !this.IsEqualIgnoreCase(sortColumn, RoutingConstants.Area))
            {
                return new BadRequestObjectResult(ValidationErrorMessages.InvalidSortColumn);
            }

            return null;
        }
    }
}
