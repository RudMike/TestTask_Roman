//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestTask_Roman.Data.Contexts;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Data.Repositories;
using TestTask_Roman.Domain;
using TestTask_Roman.Infrastructure;
using TestTask_Roman.Infrastructure.Mapping;
using TestTask_Roman.Infrastructure.Middleware;
using TestTask_Roman.Infrastructure.Repositories;
using TestTask_Roman.Infrastructure.Services;
using TestTask_Roman.Models;
using TestTask_Roman.Validators;

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

            builder.Services.AddDbContext<MedicalDbContext>(options =>
            {
                string connectionStringKey = "MySql";
                if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != null)
                {
                    connectionStringKey = "DockerSql";
                }

                var connectionString = builder.Configuration.GetConnectionString(connectionStringKey);
                options.UseSqlServer(connectionString);
            });

            _ = builder.Services.AddScoped<Func<MedicalDbContext>>(provider => () => provider.GetService<MedicalDbContext>()!);
            _ = builder.Services.AddScoped<DbContextFactory>();
            _ = builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            _ = builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            _ = builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            _ = builder.Services.AddScoped(typeof(IReportService<,,>), typeof(ReportService<,,>));
            _ = builder.Services.AddScoped<IMapper<DoctorRequest, Doctor>, DoctorRequestToEntityMapper>();
            _ = builder.Services.AddScoped<IMapper<PatientRequest, Patient>, PatientRequestToEntityMapper>();
            _ = builder.Services.AddScoped<IReportRepository<DoctorsResponse>, DoctorsRepository>();
            _ = builder.Services.AddScoped<IReportRepository<PatientsResponse>, PatientsRepository>();
            _ = builder.Services.AddScoped<PatientRequestValidator>();
            _ = builder.Services.AddScoped<DoctorRequestValidator>();
        }

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