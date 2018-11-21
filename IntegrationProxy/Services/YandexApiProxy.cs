// <copyright file="YandexApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Services
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Bot.Data.Dto;
    using Bot.IntegrationProxy.Interfaces;
    using Microsoft.Extensions.Logging;
    using Models.Response;
    using Newtonsoft.Json;
    using RestSharp;

    /// <summary>
    /// YandexApiProxy
    /// </summary>
    public class YandexApiProxy : IYandexApiProxy
    {
        private readonly YandexApiConfiguration _configuration;
        private readonly ILogger<YandexApiConfiguration> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="YandexApiProxy"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="logger">logger</param>
        public YandexApiProxy(YandexApiConfiguration configuration, ILogger<YandexApiConfiguration> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="requestParameters">requestParameters</param>
        /// <returns>ApiResponse</returns>
        public async Task<ApiResponse> GetResponseAsync(RequestParametersDto requestParameters)
        {
            var client = BuildClient();
            var request = BuildRequest(requestParameters);

            var response = await client.ExecuteGetTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var ex = response.ErrorException;
                _logger.LogError(ex, "Error during request to yandex api");
                throw ex;
            }

            return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        }

        private IRestClient BuildClient()
        {
            var uriBuilder = new UriBuilder(_configuration.BaseUrl);
            var client = new RestClient(uriBuilder.Uri);

            return client;
        }

        private IRestRequest BuildRequest(RequestParametersDto requestParameters)
        {
            var request = new RestRequest(_configuration.Resource);

            request.AddHeader("Authorization", _configuration.ApiKey);
            request.AddQueryParameter("format", _configuration.Format);
            request.AddQueryParameter("from", requestParameters.Departure);
            request.AddQueryParameter("to", requestParameters.Destination);
            request.AddQueryParameter("lang", "ru_RU");
            request.AddQueryParameter("transport_types", _configuration.TransportType);
            request.AddQueryParameter("system", _configuration.System);
            request.AddQueryParameter("date", requestParameters.DateFrom.ToShortDateString());

            return request;
        }
    }
}
