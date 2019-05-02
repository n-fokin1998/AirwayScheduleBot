// <copyright file="IIataApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services
{
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi;

    /// <summary>
    /// IIataApiProxy
    /// </summary>
    public interface IIataApiProxy
    {
        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <returns>IataApiResponse</returns>
        Task<Temp> GetResponseAsync(string searchKey);
    }
}
