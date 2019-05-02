// <copyright file="IataApiProxy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using AirwaySchedule.Bot.IntegrationProxy.Contracts.IataApi;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using AirwaySchedule.Bot.IntegrationProxy.Models;

    /// <summary>
    /// IataApiProxy
    /// </summary>
    public class IataApiProxy : IIataApiProxy
    {
        private readonly IataApiConfiguration _configuration;
        private readonly IRestSharpHelper _restSharpHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="IataApiProxy"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="restSharpHelper">restSharpHelper</param>
        public IataApiProxy(IataApiConfiguration configuration, IRestSharpHelper restSharpHelper)
        {
            _configuration = configuration;
            _restSharpHelper = restSharpHelper;
        }

        /// <summary>
        /// GetResponseAsync
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <returns>IataApiResponse</returns>
        public async Task<Temp> GetResponseAsync(string searchKey)
        {
            var client = _restSharpHelper.CreateClient(_configuration.BaseUrl);
            var request = _restSharpHelper.CreateRequest(_configuration.Resource, BuildQueryParameters(searchKey));

            var response = await client.ExecuteGetTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var exception = response.ErrorException;

                throw exception;
            }

            return JsonConvert.DeserializeObject<Temp>(response.Content);
        }

        private IDictionary<string, string> BuildQueryParameters(string searchKey)
        {
            var parameters = new Dictionary<string, string>
            {
                { "api_key", _configuration.ApiKey },
                { "query", searchKey }
            };

            return parameters;
        }
    }
}
