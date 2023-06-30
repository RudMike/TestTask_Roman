//-----------------------------------------------------------------------
// <copyright file="PacientRequestToEntityMapper.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Models;
using TestTask_Roman.Models;

namespace TestTask_Roman.Infrastructure.Mapping
{
    /// <summary>
    /// Maps between a <see cref="PatientRequest"/> object and a <see cref="Patient"/> entity.
    /// </summary>
    public class PacientRequestToEntityMapper : IMapper<PatientRequest, Patient>
    {
        /// <inheritdoc/>
        public Patient Map(PatientRequest from)
        {
            var patient = new Patient()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                MiddleName = from.MiddleName,
                Address = from.Address,
                AreaId = from.Area,
                BirthDate = from.BirthDate,
                Sex = from.Sex,
            };

            return patient;
        }
    }
}
