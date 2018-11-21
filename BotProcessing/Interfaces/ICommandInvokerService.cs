// <copyright file="ICommandInvokerService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// ICommandInvokerService
    /// </summary>
    public interface ICommandInvokerService
    {
        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="message">message</param>
        void ExecuteCommand(long chatId, string message);
    }
}
