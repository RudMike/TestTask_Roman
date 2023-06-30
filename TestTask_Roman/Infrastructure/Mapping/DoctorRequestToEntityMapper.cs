//-----------------------------------------------------------------------
// <copyright file="DoctorRequestToEntityMapper.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Models;
using TestTask_Roman.Models;

namespace TestTask_Roman.Infrastructure.Mapping
{
    /// <summary>
    /// Maps between a <see cref="DoctorRequest"/> object and a <see cref="Doctor"/> entity.
    /// </summary>
    public class DoctorRequestToEntityMapper : IMapper<DoctorRequest, Doctor>
    {
        /// <inheritdoc/>
        public Doctor Map(DoctorRequest from)
        {
            var doctor = new Doctor()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                MiddleName = from.MiddleName,
                RoomId = from.Room,
                SpecializationId = from.SpecializationId,
                AreaId = from.Area,
            };

            return doctor;
        }
    }
}
