//-----------------------------------------------------------------------
// <copyright file="ExceptionHandlerMiddleware.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
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
            string? result;

            switch (ex)
            {
                case BadRequestException restEx:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    result = restEx.Message;
                    break;

                case DbUpdateException dbEx:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    result = $"{dbEx.Message} Inner exception: {dbEx.InnerException!.Message}.";
                    break;

                case ValidationException validEx:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    result = $"{validEx.Message}.";
                    break;

                case OperationCanceledException cancEx:
                    context.Response.StatusCode = StatusCodes.Status204NoContent;
                    result = cancEx.Message;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    result = ex.Message;
                    break;
            }

            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(result);
        }
    }
}
