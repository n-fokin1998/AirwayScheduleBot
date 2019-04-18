// <copyright file="ICommandInvokerService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// ICommandInvokerService
    /// </summary>
    public interface ICommandInvokerService
    {
        /// <summary>
        /// ExecuteCommandAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="message">message</param>
        /// <returns>Task</returns>
        Task ExecuteCommandAsync(long chatId, string message);
    }
}
