// <copyright file="RequestParametersDto.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Data.Dto
{
    using System;

    /// <summary>
    /// RequestParametersDto
    /// </summary>
    public class RequestParametersDto
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
        /// DateFrom
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// DateTo
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
