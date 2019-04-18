// <copyright file="IataApiConfiguration.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Models
{
    /// <summary>
    /// IataApiConfiguration
    /// </summary>
    public class IataApiConfiguration
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
    }
}
