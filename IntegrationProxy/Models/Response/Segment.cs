// <copyright file="Segment.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models.Response
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Segment
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// Arrival
        /// </summary>
        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        /// <summary>
        /// Departure
        /// </summary>
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        /// <summary>
        /// DeparturePoint
        /// </summary>
        [JsonProperty("from")]
        public DeparturePoint DeparturePoint { get; set; }

        /// <summary>
        /// ArrivalPoint
        /// </summary>
        [JsonProperty("to")]
        public ArrivalPoint ArrivalPoint { get; set; }

        /// <summary>
        /// Thread
        /// </summary>
        [JsonProperty("thread")]
        public Thread Thread { get; set; }
    }
}
