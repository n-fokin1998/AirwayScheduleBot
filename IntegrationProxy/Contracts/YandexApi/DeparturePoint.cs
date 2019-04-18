// <copyright file="DeparturePoint.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// DeparturePoint
    /// </summary>
    public class DeparturePoint
    {
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
