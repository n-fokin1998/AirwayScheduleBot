// <copyright file="RequestStrategyBase.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator.Strategies
{
    using System;
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.BotProcessing.Extensions;
    using AirwaySchedule.Bot.Common.Exceptions;
    using AirwaySchedule.Bot.Common.Models;

    /// <summary>
    /// RequestStrategyBase
    /// </summary>
    public class RequestStrategyBase
    {
        private const string DateFormatErrorMessage = "😒 Invalid date format";
        private const string CommandFormatErrorMessage = "😒 Invalid command format";

        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <param name="getRequestModelAction">getRequestModelAction</param>
        /// <returns>RequestParameters</returns>
        protected async Task<RequestParameters> CreateRequest(
            long chatId,
            string commandText,
            Func<string, string, Task<RequestParameters>> getRequestModelAction)
        {
            var requestParameters = commandText.GetCommandParameters();

            if (requestParameters.Length < 3)
            {
                throw new BotCommandException(chatId, CommandFormatErrorMessage);
            }

            var requestModel = await getRequestModelAction(requestParameters[0], requestParameters[1]);

            if (!DateTime.TryParse(requestParameters[2], out var fromDate))
            {
                throw new BotCommandException(chatId, DateFormatErrorMessage);
            }

            requestModel.Date = fromDate;

            return requestModel;
        }
    }
}
