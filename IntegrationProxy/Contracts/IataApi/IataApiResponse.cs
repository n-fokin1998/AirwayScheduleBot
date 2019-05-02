// <copyright file="IataApiResponse.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// IataApiResponse
    /// </summary>
    public class IataApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IataApiResponse"/> class.
        /// </summary>
        public IataApiResponse()
        {
            Cities = new List<City>();
            Airports = new List<Airport>();
        }

        /// <summary>
        /// Cities
        /// </summary>
        [JsonProperty("cities")]
        public List<City> Cities { get; set; }

        /// <summary>
        /// Airports
        /// </summary>
        [JsonProperty("airports")]
        public List<Airport> Airports { get; set; }
    }
}
