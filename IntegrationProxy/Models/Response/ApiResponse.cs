// <copyright file="ApiResponse.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// ApiResponse
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse()
        {
            Segments = new List<Segment>();
        }

        /// <summary>
        /// Segments
        /// </summary>
        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }
    }
}
