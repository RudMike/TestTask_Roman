//-----------------------------------------------------------------------
// <copyright file="ExceptionHandlerMiddleware.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask_Roman.Infrastructure.Exceptions;

namespace TestTask_Roman.Infrastructure.Middleware
{
    /// <summary>
    /// Middleware for handling exceptions that occur during request processing.
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The request delegate to invoke if no exceptions occur.</param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invokes the middleware to handle exceptions that occur during request processing.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex, context);
            }
        }

        private static async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            int status;
            string title;
            string detail;

            switch (ex)
            {
                case BadRequestException restEx:
                    status = StatusCodes.Status400BadRequest;
                    title = "Bad Request";
                    detail = restEx.Message;
                    break;

                case DbUpdateException dbEx:
                    status = StatusCodes.Status500InternalServerError;
                    title = "Database Update Error";
                    detail = $"{dbEx.Message} Inner exception: {dbEx.InnerException?.Message}.";
                    break;

                case ValidationException validEx:
                    status = StatusCodes.Status400BadRequest;
                    title = "Validation Error";
                    detail = validEx.Message;
                    break;

                case OperationCanceledException cancEx:
                    status = StatusCodes.Status204NoContent;
                    title = "Operation Canceled";
                    detail = cancEx.Message;
                    break;

                default:
                    status = StatusCodes.Status500InternalServerError;
                    title = "Internal Server Error";
                    detail = ex.Message;
                    break;
            }

            var problemDetails = new ProblemDetails
            {
                Title = title,
                Detail = detail,
                Status = status,
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
