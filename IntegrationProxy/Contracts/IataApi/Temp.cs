// <copyright file="Temp.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi
{
    using Newtonsoft.Json;

    /// <summary>
    /// Temp
    /// </summary>
    public class Temp
    {
        /// <summary>
        /// Response
        /// </summary>
        [JsonProperty("response")]
        public IataApiResponse Response { get; set; }
    }
}
