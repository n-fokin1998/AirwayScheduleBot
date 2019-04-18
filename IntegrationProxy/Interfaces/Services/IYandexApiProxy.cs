// <copyright file="IYandexApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services
{
    using System.Threading.Tasks;

    using Contracts.YandexApi;

    using Common.Models;

    /// <summary>
    /// IYandexApiProxy
    /// </summary>
    public interface IYandexApiProxy
    {
        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="requestParameters">requestParameters</param>
        /// <returns>YandexApiResponse</returns>
        Task<YandexApiResponse> GetResponseAsync(RequestParameters requestParameters);
    }
}
