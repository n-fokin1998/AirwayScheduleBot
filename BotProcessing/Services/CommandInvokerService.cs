// <copyright file="CommandInvokerService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AirwaySchedule.Bot.BotProcessing.Extensions;
    using Interfaces.Services;
    using Interfaces.Services.Commands;
    using AirwaySchedule.Bot.Common.Utils;
    using AirwaySchedule.Bot.BotProcessing.Models;

    /// <summary>
    /// CommandInvokerService
    /// </summary>
    public class CommandInvokerService : ICommandInvokerService
    {
        private readonly IDictionary<string, ICommandService> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandInvokerService"/> class.
        /// </summary>
        /// <param name="scheduleCommandService">scheduleCommandService</param>
        /// <param name="planeDetailsCommandService">planeDetailsCommandService</param>
        /// <param name="helpCommandService">helpCommandService</param>
        /// <param name="setEmailCommandService">setEmailCommandService</param>
        public CommandInvokerService(
            IScheduleCommandService scheduleCommandService,
            IPlaneDetailsCommandService planeDetailsCommandService,
            IHelpCommandService helpCommandService,
            ISetEmailCommandService setEmailCommandService)
        {
            _commands = new Dictionary<string, ICommandService>
            {
                { CommandNames.ScheduleByIataCommand, scheduleCommandService },
                { CommandNames.ScheduleByCityCommand, scheduleCommandService },
                { CommandNames.ScheduleByAirportCommand, scheduleCommandService },
                { CommandNames.PlaneDetailsCommand, planeDetailsCommandService },
                { CommandNames.HelpCommand, helpCommandService },
                { CommandNames.SetEmailCommand, setEmailCommandService }
            };
        }

        /// <summary>
        /// ExecuteCommandAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="message">message</param>
        /// <returns>Task</returns>
        public async Task ExecuteCommandAsync(long chatId, string message)
        {
            var command = new Command
            {
                Name = message.GetCommandName(),
                Text = message.GetCommandText()
            };

            var commandService = GetCommandService(command.Name);

            if (commandService != null)
            {
                await commandService.ExecuteAsync(chatId, command);
            }
        }

        private ICommandService GetCommandService(string commandName)
        {
            return _commands.ContainsKey(commandName) ? _commands[commandName] : null;
        }
    }
}
