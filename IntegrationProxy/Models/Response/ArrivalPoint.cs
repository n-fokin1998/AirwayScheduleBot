// <copyright file="ArrivalPoint.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// ArrivalPoint
    /// </summary>
    public class ArrivalPoint
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
