//-----------------------------------------------------------------------
// <copyright file="PatientsController.cs" company="RudMike">
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
    /// Represents a controller that handles requests related to patients.
    /// </summary>
    [Route("Patients")]
    public class PatientsController : Controller
    {
        private readonly IReportService<Patient, PatientsResponse, PatientRequest> patientService;
        private readonly PatientControllerRequestValidator requestValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsController"/> class with the specified patient service and request validator.
        /// </summary>
        /// <param name="patientService">The service used to interact with patient entities and generate reports.</param>
        /// <param name="requestValidator">The validator used to validate patient requests.</param>
        public PatientsController(
            IReportService<Patient, PatientsResponse, PatientRequest> patientService,
            PatientControllerRequestValidator requestValidator)
        {
            this.patientService = patientService;
            this.requestValidator = requestValidator;
        }

        /// <summary>
        /// Retrieves a report of patient entities sorted and paginated according to the specified parameters asynchronously.
        /// </summary>
        /// <param name="sortColumn">The name of the column to sort the results by.
        /// Available <see langword="null"/> or next values: "address", "area", "birthdate", "firstname", "id", "lastname", "middlename", "sex".
        /// Default is <c>id</c>.</param>
        /// <param name="sortOrder">The order to sort the results. Available next values: "asc", "desc".</param>
        /// <param name="page">The page number of the results to retrieve. Available positive values or <see langword="null"/>.</param>
        /// <param name="pageSize">The number of results per page to retrieve. Available positive values or <see langword="null"/>.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with an array of patient entities and pagination information.</returns>
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

            var patients = await this.patientService
                .GetReportAsync(sortColumn, sortOrder, page, pageSize, ct)
                .ConfigureAwait(false);

            return patients.TotalCount != 0 ? this.Ok(patients) : this.NoContent();
        }

        /// <summary>
        /// Retrieves the patient entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the patient entity to retrieve.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with the patient entity.</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateId(id);

            if (validationResult != null)
            {
                return validationResult;
            }

            var patient = await this.patientService
                .GetByIdAsync(id, ct)
                .ConfigureAwait(false);

            return patient != null ? this.Ok(patient) : this.NotFound();
        }

        /// <summary>
        /// Adds a new patient entity asynchronously.
        /// </summary>
        /// <param name="patient">The patient entity to add.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with the added patient entity.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] PatientRequest patient, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateRequest(patient, this.ModelState);

            if (validationResult != null)
            {
                return validationResult;
            }

            var addedEntity = await this.patientService
                .AddAsync(patient, ct)
                .ConfigureAwait(false);

            return this.Ok(addedEntity);
        }

        /// <summary>
        /// Updates an existing patient entity asynchronously.
        /// </summary>
        /// <param name="patient">The patient entity to update.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation.</param>
        /// <returns>An HTTP response indicating success or failure, along with the edited patient entity.</returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> EditAsync([FromBody] PatientRequest patient, CancellationToken ct = default)
        {
            var validationResult = this.requestValidator
                .ValidateRequest(patient, this.ModelState);

            if (validationResult != null)
            {
                return validationResult;
            }

            var updatedEntity = await this.patientService
                .UpdateAsync(patient, ct)
                .ConfigureAwait(false);

            return this.Ok(updatedEntity);
        }

        /// <summary>
        /// Deletes the patient entity with the specified ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the patient entity to delete.</param>
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

            _ = await this.patientService
                .DeleteAsync(id, ct)
                .ConfigureAwait(false);

            return this.NoContent();
        }
    }
}
