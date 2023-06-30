//-----------------------------------------------------------------------
// <copyright file="DoctorsController.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using TestTask_Roman.Data.Models;
using TestTask_Roman.Domain;
using TestTask_Roman.Models;
using TestTask_Roman.Validators;

namespace TestTask_Roman.Controllers
{
    /// <summary>
    /// Represents a controller that handles requests related to doctors.
    /// </summary>
    [Route("Doctors")]
    public class DoctorsController : Controller
    {
        private readonly IReportService<Doctor, DoctorsResponse, DoctorRequest> doctorService;
        private readonly DoctorControllerRequestValidator requestValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorsController"/> class with the specified doctor service and request validator.
        /// </summary>
        /// <param name="doctorService">The service used to interact with doctor entities and generate reports.</param>
        /// <param name="requestValidator">The validator used to validate doctor requests.</param>
        public DoctorsController(
            IReportService<Doctor, DoctorsResponse, DoctorRequest> doctorService,
            DoctorControllerRequestValidator requestValidator)
        {
            this.doctorService = doctorService;
            this.requestValidator = requestValidator;
        }

        /// <summary>
        /// Retrieves a report of doctor entities sorted and paginated according to the specified parameters asynchronously.
        /// </summary>
        /// <param name="sortColumn">The name of the column to sort the results by.
        /// Available <see langword="null"/> or next values: "area", "firstname", "id", "lastname", "middlename", "room", "specialization".
        /// Default is <c>id</c>.</param>
        /// <param name="sortOrder">The order to sort the results. Available next values: "asc", "desc".</param>
        /// <param name="page">The page number of the results to retrieve. Available positive values or <see langword="null"/>.</param>
        /// <param name="pageSize">The number of results per page to retrieve. Available positive values or <see langword="null"/>.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with an array of doctor entities and pagination information.</returns>
        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReportAsync(
            [FromQuery] string? sortColumn,
            [FromQuery] string? sortOrder,
            [FromQuery] int? page,
            [FromQuery] int? pageSize,
            CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateRequest(sortColumn, sortOrder, page, pageSize);

            if (validationResult != null)
            {
                return validationResult;
            }

            var doctors = await this.doctorService
                .GetReportAsync(sortColumn, sortOrder, page, pageSize, ct)
                .ConfigureAwait(false);

            return doctors.TotalCount != 0 ? this.Ok(doctors) : this.NoContent();
        }

        /// <summary>
        /// Retrieves the doctor entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the doctor entity to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with the doctor entity.</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateId(id);

            if (validationResult != null)
            {
                return validationResult;
            }

            var doctor = await this.doctorService
                .GetByIdAsync(id, ct)
                .ConfigureAwait(false);

            return doctor != null ? this.Ok(doctor) : this.NotFound();
        }

        /// <summary>
        /// Adds a new doctor entity asynchronously.
        /// </summary>
        /// <param name="doctor">The doctor entity to add.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] DoctorRequest doctor, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateRequest(doctor, this.ModelState);

            if (validationResult != null)
            {
                return validationResult;
            }

            var processedCount = await this.doctorService
                .AddAsync(doctor, ct)
                .ConfigureAwait(false);

            return processedCount != 0 ? this.Ok() : this.UnprocessableEntity();
        }

        /// <summary>
        /// Updates an existing doctor entity asynchronously.
        /// </summary>
        /// <param name="doctor">The doctor entity to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> EditAsync([FromBody] DoctorRequest doctor, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateRequest(doctor, this.ModelState);

            if (validationResult != null)
            {
                return validationResult;
            }

            var processedCount = await this.doctorService
                .UpdateAsync(doctor, ct)
                .ConfigureAwait(false);

            return processedCount != 0 ? this.Ok() : this.UnprocessableEntity();
        }

        /// <summary>
        /// Deletes the doctor entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the doctor entity to delete.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateId(id);

            if (validationResult != null)
            {
                return validationResult;
            }

            _ = await this.doctorService
                .DeleteAsync(id, ct)
                .ConfigureAwait(false);

            return this.NoContent();
        }
    }
}
