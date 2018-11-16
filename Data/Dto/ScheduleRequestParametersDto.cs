// <copyright file="ScheduleRequestParametersDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TransportScheduleAssistant.Data.Dto
{
    using System;
    using TransportScheduleAssistant.Data.Enums;

    /// <summary>
    /// ScheduleRequestParametersDto
    /// </summary>
    public class ScheduleRequestParametersDto
    {
        /// <summary>
        /// Departure
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Destination
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// TransportType
        /// </summary>
        public TransportType TransportType { get; set; }
    }
}
