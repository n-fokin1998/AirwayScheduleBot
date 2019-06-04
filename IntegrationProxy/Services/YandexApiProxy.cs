// <copyright file="YandexApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Contracts.YandexApi;

    using Common.Models;
    using AirwaySchedule.Bot.Common.Extensions;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using AirwaySchedule.Bot.IntegrationProxy.Models;

    /// <summary>
    /// YandexApiProxy
    /// </summary>
    public class YandexApiProxy : IYandexApiProxy
    {
        private readonly YandexApiConfiguration _configuration;
        private readonly IRestSharpHelper _restSharpHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="YandexApiProxy"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="restSharpHelper">restSharpHelper</param>
        public YandexApiProxy(YandexApiConfiguration configuration, IRestSharpHelper restSharpHelper)
        {
            _configuration = configuration;
            _restSharpHelper = restSharpHelper;
        }

        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="requestParameters">requestParameters</param>
        /// <returns>YandexApiResponse</returns>
        public async Task<YandexApiResponse> GetResponseAsync(RequestParameters requestParameters)
        {
            var client = _restSharpHelper.CreateClient(_configuration.BaseUrl);
            var request = _restSharpHelper.CreateRequest(_configuration.Resource, BuildQueryParameters(requestParameters));

            var response = await client.ExecuteGetTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var exception = response.ErrorException;

                throw exception;
            }

            return JsonConvert.DeserializeObject<YandexApiResponse>(response.Content);
        }

        private IDictionary<string, string> BuildQueryParameters(RequestParameters requestParameters)
        {
            var parameters = new Dictionary<string, string>
            {
                { "apikey", _configuration.ApiKey },
                { "format", _configuration.Format },
                { "from", requestParameters.Departure },
                { "to", requestParameters.Destination },
                { "lang", _configuration.Language },
                { "transport_types", _configuration.TransportType },
                { "system", _configuration.System },
                { "date", requestParameters.Date.ToIsoString() }
            };

            return parameters;
        }
    }
}
