// <copyright file="CommandInvokerService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services
{
    using System.Collections.Generic;
    using AirwaySchedule.Bot.BotProcessing.Extensions;
    using AirwaySchedule.Bot.BotProcessing.Interfaces;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Commands;

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
        /// <param name="languageCommandService">languageCommandService</param>
        /// <param name="planeDetailsCommandService">planeDetailsCommandService</param>
        /// <param name="emailCommandService">emailCommandService</param>
        public CommandInvokerService(
            IScheduleCommandService scheduleCommandService,
            ILanguageCommandService languageCommandService,
            IPlaneDetailsCommandService planeDetailsCommandService,
            IEmailCommandService emailCommandService)
        {
            _commands = new Dictionary<string, ICommandService>
            {
                { "/get", scheduleCommandService },
                { "/language", languageCommandService },
                { "/plane", planeDetailsCommandService },
                { "/email", emailCommandService }
            };
        }

        /// <summary>
        /// ExecuteCommand
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="message">message</param>
        public async void ExecuteCommand(long chatId, string message)
        {
            var commandName = message.GetCommandName();
            var commandText = message.GetCommandText();

            var commandService = GetCommandService(commandName);

            if (commandService != null)
            {
                await commandService.ExecuteAsync(chatId, commandText);
            }
        }

        private ICommandService GetCommandService(string commandName)
        {
            return _commands.ContainsKey(commandName) ? _commands[commandName] : null;
        }
    }
}
