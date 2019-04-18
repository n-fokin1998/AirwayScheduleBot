// <copyright file="IScheduleRequestCreator.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure.ScheduleRequestCreator
{
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.BotProcessing.Models;
    using Common.Models;

    /// <summary>
    /// IScheduleRequestCreator
    /// </summary>
    public interface IScheduleRequestCreator
    {
        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>RequestParameters</returns>
        Task<RequestParameters> CreateRequest(long chatId, Command command);
    }
}
