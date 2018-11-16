// <copyright file="IYandexApiProxy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace TransportScheduleAssistant.IntegrationProxy.Interfaces
{
    using System.Threading.Tasks;
    using TransportScheduleAssistant.Data.Dto;
    using TransportScheduleAssistant.Data.ViewModels;

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
        Task<ApiResponse> GetResponseAsync(ScheduleRequestParametersDto requestParameters);
    }
}
