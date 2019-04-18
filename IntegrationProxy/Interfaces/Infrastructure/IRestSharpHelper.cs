// <copyright file="IRestSharpHelper.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.IntegrationProxy.Interfaces.Infrastructure
{
    using System.Collections.Generic;

    using RestSharp;

    /// <summary>
    /// IRestSharpHelper
    /// </summary>
    public interface IRestSharpHelper
    {
        /// <summary>
        /// Create rest sharp client.
        /// </summary>
        /// <param name="url">Base url.</param>
        /// <returns>IRestClient</returns>
        IRestClient CreateClient(string url);

        /// <summary>
        /// Create rest sharp request.
        /// </summary>
        /// <param name="resource">Resource path.</param>
        /// <param name="queryParameters">Query parameters for the request.</param>
        /// <returns>IRestRequest</returns>
        IRestRequest CreateRequest(string resource, IDictionary<string, string> queryParameters);
    }
}
