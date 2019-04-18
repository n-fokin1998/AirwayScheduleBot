// <copyright file="YandexApiConfiguration.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models
{
    /// <summary>
    /// YandexApiConfiguration
    /// </summary>
    public class YandexApiConfiguration
    {
        /// <summary>
        /// ApiKey
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// BaseUrl
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Resource
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// TransportType
        /// </summary>
        public string TransportType { get; set; }

        /// <summary>
        /// System
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }
    }
}
