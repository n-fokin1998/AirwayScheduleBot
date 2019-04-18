// <copyright file="IScheduleRequestStrategy.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure.ScheduleRequestCreator
{
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.Common.Models;

    /// <summary>
    /// IScheduleRequestStrategy
    /// </summary>
    public interface IScheduleRequestStrategy
    {
        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <returns>RequestParameters</returns>
        Task<RequestParameters> CreateRequest(long chatId, string commandText);
    }
}
