//-----------------------------------------------------------------------
// <copyright file="BaseRequestValidatorFilter.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestTask_Roman.Constants;
using TestTask_Roman.Validators;

namespace TestTask_Roman.Filters
{
    /// <summary>
    /// Base class for request validation filters.
    /// </summary>
    public abstract class BaseRequestValidatorFilter : Attribute, IAsyncActionFilter
    {
        private readonly object validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRequestValidatorFilter"/> class.
        /// </summary>
        /// <param name="validator">The validator used for validation. Make sure it implements <see cref="BaseRequestValidator{TRequest}"/>.</param>
        protected BaseRequestValidatorFilter(object validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Gets the validator object used for validation.
        /// </summary>
        protected object Validator => this.validator;

        /// <inheritdoc/>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = this.ValidateRequest(context.ActionArguments, context);

            if (result != null)
            {
                context.Result = result;
                return;
            }

            await next();
        }

        /// <summary>
        /// Validates the passed model object.
        /// </summary>
        /// <param name="model">The model object to be validated.</param>
        /// <param name="context">The action executing context.</param>
        /// <returns>An <see cref="ActionResult"/> if validation fails, otherwise <see langword="null"/>.</returns>
        protected abstract ActionResult? ValidateModel(object model, ActionExecutingContext context);

        /// <summary>
        /// Validates the ID parameter.
        /// </summary>
        /// <param name="id">The ID parameter to be validated.</param>
        /// <returns>An <see cref="ActionResult"/> if validation fails, otherwise <see langword="null"/>.</returns>
        protected ActionResult? ValidateId(int id)
        {
            return ((dynamic)this.Validator).ValidateId(id);
        }

        /// <summary>
        /// Validates the pagination parameters.
        /// </summary>
        /// <param name="actionArguments">The action arguments.</param>
        /// <returns>An <see cref="ActionResult"/> if validation fails, otherwise <see langword="null"/>.</returns>
        protected ActionResult? ValidatePagination(IDictionary<string, object?> actionArguments)
        {
            actionArguments.TryGetValue(RoutingConstants.SortColumn, out var sortColumn);
            actionArguments.TryGetValue(RoutingConstants.SortOrder, out var sortOrder);
            actionArguments.TryGetValue(RoutingConstants.Page, out var page);
            actionArguments.TryGetValue(RoutingConstants.PageSize, out var pageSize);
            return ((dynamic)this.Validator).ValidateRequest((string?)sortColumn, (string?)sortOrder, (int?)page, (int?)pageSize);
        }

        /// <summary>
        /// Determines whether the given key is the ID key.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><see langword="true"/> if the key is the ID key, otherwise <see langword="false"/>.</returns>
        protected bool IsIdKey(string? key)
        {
            return string.Equals(key, RoutingConstants.Id, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the given key is a pagination key.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns><see langword="true"/> if the key is a pagination key, otherwise <see langword="false"/>.</returns>
        protected bool IsPaginationKey(string? key)
        {
            return string.Equals(key, RoutingConstants.SortColumn, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(key, RoutingConstants.SortOrder, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(key, RoutingConstants.Page, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(key, RoutingConstants.PageSize, StringComparison.OrdinalIgnoreCase);
        }

        private ActionResult? ValidateRequest(IDictionary<string, object?> arguments, ActionExecutingContext context)
        {
            ActionResult? result = null;

            foreach (var argument in arguments)
            {
                var argumentKey = argument.Key;

                if (this.IsIdKey(argumentKey))
                {
                    result = this.ValidateId((int)argument.Value!);
                    break;
                }
                else if (this.IsPaginationKey(argumentKey))
                {
                    result = this.ValidatePagination(arguments);
                    break;
                }
                else if (argument.Value is object request)
                {
                    result = this.ValidateModel(request, context);
                    break;
                }
            }

            return result;
        }
    }
}
