//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
namespace TestTask_Roman
{
    /// <summary>
    /// The main entry point for the web API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the web application and starts listening for incoming requests.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            ConfigureMiddleware(app);
            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MedicalAPI",
                    Description = "Provides access to doctors and patients",
                    Contact = new OpenApiContact
                    {
                        Name = "Mike Rudnikov",
                        Url = new Uri("https://t.me/rudmike"),
                    },
                });
            });
        private static void ConfigureMiddleware(WebApplication app)
        {
            _ = app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseAuthorization();
            _ = app.MapControllers();
        }
    }
}