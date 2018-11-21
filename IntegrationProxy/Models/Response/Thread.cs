// <copyright file="Thread.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// Thread
    /// </summary>
    public class Thread
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Vehicle
        /// </summary>
        [JsonProperty("vehicle")]
        public string Vehicle { get; set; }

        /// <summary>
        /// Carrier
        /// </summary>
        [JsonProperty("carrier")]
        public Carrier Carrier { get; set; }
    }
}
