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
        /// ExecuteCommandAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandName">commandName</param>
        /// <param name="commandText">commandText</param>
        void ExecuteCommandAsync(long chatId, string commandName, string commandText);
    }
}
