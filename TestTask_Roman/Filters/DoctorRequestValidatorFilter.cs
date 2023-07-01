//-----------------------------------------------------------------------
// <copyright file="DoctorRequestValidatorFilter.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestTask_Roman.Models;
using TestTask_Roman.Validators;

namespace TestTask_Roman.Filters
{
    /// <summary>
    /// A filter attribute that validates requests for the doctor controller.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DoctorRequestValidatorFilter : BaseRequestValidatorFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorRequestValidatorFilter"/> class.
        /// </summary>
        /// <param name="validator">The validator used for doctor request validation. Make sure it is an instance of <see cref="DoctorRequestValidator"/>.</param>
        public DoctorRequestValidatorFilter(DoctorRequestValidator validator)
            : base(validator)
        {
        }

        /// <inheritdoc/>
        protected override ActionResult? ValidateModel(object model, ActionExecutingContext context)
        {
            if (model is DoctorRequest doctorRequest)
            {
                return ((DoctorRequestValidator)this.Validator).ValidateRequest(doctorRequest, context.ModelState);
            }

            return null;
        }
    }
}
