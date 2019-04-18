// <copyright file="YandexApiResponse.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// YandexApiResponse
    /// </summary>
    public class YandexApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YandexApiResponse"/> class.
        /// </summary>
        public YandexApiResponse()
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
