// <copyright file="Airport.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// Airport
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Airport code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Airport name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
