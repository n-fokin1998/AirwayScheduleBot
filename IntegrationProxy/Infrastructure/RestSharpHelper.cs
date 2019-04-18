// <copyright file="RestSharpHelper.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using RestSharp;

    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Infrastructure;

    /// <summary>
    /// RestSharpHelper
    /// </summary>
    public class RestSharpHelper : IRestSharpHelper
    {
        /// <summary>
        /// Create rest sharp client.
        /// </summary>
        /// <param name="url">Base url.</param>
        /// <returns>IRestClient</returns>
        public IRestClient CreateClient(string url)
        {
            var uriBuilder = new UriBuilder(url);
            var client = new RestClient(uriBuilder.Uri);

            return client;
        }

        /// <summary>
        /// Create rest sharp request.
        /// </summary>
        /// <param name="resource">Resource path.</param>
        /// <param name="queryParameters">Query parameters for the request.</param>
        /// <returns>IRestRequest</returns>
        public IRestRequest CreateRequest(string resource, IDictionary<string, string> queryParameters)
        {
            var request = new RestRequest(resource);

            foreach (var parameter in queryParameters)
            {
                request.AddQueryParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}
