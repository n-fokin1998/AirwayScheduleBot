// <copyright file="Carrier.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// Carrier
    /// </summary>
    public class Carrier
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
