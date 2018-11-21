// <copyright file="ICommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Commands
{
    using System.Threading.Tasks;

    /// <summary>
    /// ICommandService
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <returns>Task</returns>
        Task ExecuteAsync(long chatId, string commandText);
    }
}
