// <copyright file="RequestParameters.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Common.Models
{
    using System;

    /// <summary>
    /// RequestParameters
    /// </summary>
    public class RequestParameters
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
    }
}
