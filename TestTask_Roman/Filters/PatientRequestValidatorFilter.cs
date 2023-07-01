//-----------------------------------------------------------------------
// <copyright file="PatientRequestValidatorFilter.cs" company="RudMike">
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
    /// A filter attribute that validates requests for the patient controller.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PatientRequestValidatorFilter : BaseRequestValidatorFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRequestValidatorFilter"/> class with the specified <see cref="PatientRequestValidator"/>.
        /// </summary>
        /// <param name="validator">The validator to use for request validation.</param>
        public PatientRequestValidatorFilter(PatientRequestValidator validator)
            : base(validator)
        {
        }

        /// <inheritdoc/>
        protected override ActionResult? ValidateModel(object model, ActionExecutingContext context)
        {
            if (model is PatientRequest patientRequest)
            {
                return ((PatientRequestValidator)this.Validator).ValidateRequest(patientRequest, context.ModelState);
            }

            return null;
        }
    }
}
