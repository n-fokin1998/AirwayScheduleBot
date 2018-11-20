// <copyright file="IYandexApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Interfaces
{
    using System.Threading.Tasks;
    using Bot.Data.Dto;
    using Bot.Data.ViewModels;

    /// <summary>
    /// IYandexApiProxy
    /// </summary>
    public interface IYandexApiProxy
    {
        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="requestParameters">requestParameters</param>
        /// <returns>ApiResponse</returns>
        Task<ApiResponse> GetResponseAsync(RequestParametersDto requestParameters);
    }
}
