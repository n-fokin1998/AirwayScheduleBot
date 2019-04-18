// <copyright file="RequestByIataStrategy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator.Strategies
{
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.Common.Models;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure.ScheduleRequestCreator;

    /// <summary>
    /// RequestByCityStrategy
    /// </summary>
    public class RequestByIataStrategy : RequestStrategyBase, IScheduleRequestStrategy
    {
        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <returns>RequestParameters</returns>
        public async Task<RequestParameters> CreateRequest(long chatId, string commandText)
        {
            return await CreateRequest(chatId, commandText, async (departure, destination) =>
            {
                return await new Task<RequestParameters>(() => new RequestParameters
                {
                    Departure = departure,
                    Destination = destination
                });
            });
        }
    }
}
