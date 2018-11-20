// <copyright file="YandexApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace TransportScheduleAssistant.IntegrationProxy.Services
{
    using System.Threading.Tasks;
    using TransportScheduleAssistant.Data.Dto;
    using TransportScheduleAssistant.Data.ViewModels;
    using TransportScheduleAssistant.IntegrationProxy.Interfaces;
    using TransportScheduleAssistant.IntegrationProxy.Models;

    /// <summary>
    /// YandexApiProxy
    /// </summary>
    public class YandexApiProxy : IYandexApiProxy
    {
        private readonly YandexApiConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="YandexApiProxy"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        public YandexApiProxy(YandexApiConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="requestParameters">requestParameters</param>
        /// <returns>ApiResponse</returns>
        public Task<ApiResponse> GetResponseAsync(ScheduleRequestParametersDto requestParameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
