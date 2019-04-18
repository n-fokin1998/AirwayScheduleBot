// <copyright file="City.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// City
    /// </summary>
    public class City
    {
        /// <summary>
        /// City code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
