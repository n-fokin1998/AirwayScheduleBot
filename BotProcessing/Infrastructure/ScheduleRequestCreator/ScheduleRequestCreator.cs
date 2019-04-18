// <copyright file="ScheduleRequestCreator.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator
{
    using System.Threading.Tasks;

    using Autofac.Features.Indexed;
    using Common.Models;

    using Interfaces.Infrastructure.ScheduleRequestCreator;
    using AirwaySchedule.Bot.BotProcessing.Models;

    /// <summary>
    /// ScheduleRequestCreator
    /// </summary>
    public class ScheduleRequestCreator : IScheduleRequestCreator
    {
        private readonly IIndex<string, IScheduleRequestStrategy> _strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRequestCreator"/> class.
        /// </summary>
        /// <param name="strategies">strategies</param>
        public ScheduleRequestCreator(IIndex<string, IScheduleRequestStrategy> strategies)
        {
            _strategies = strategies;
        }

        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>RequestParameters</returns>
        public async Task<RequestParameters> CreateRequest(long chatId, Command command)
        {
            return await _strategies[command.Name].CreateRequest(chatId, command.Text);
        }
    }
}
