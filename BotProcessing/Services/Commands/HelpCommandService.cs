// <copyright file="HelpCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System.Threading.Tasks;

    using Telegram.Bot;

    using AirwaySchedule.Bot.BotProcessing.Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;

    /// <summary>
    /// HelpCommandService
    /// </summary>
    public class HelpCommandService : IHelpCommandService
    {
        private readonly ITelegramBotClient _telegramBotClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommandService"/> class.
        /// </summary>
        /// <param name="telegramBotClient">telegramBotClient</param>
        public HelpCommandService(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>Task</returns>
        public async Task ExecuteAsync(long chatId, Command command)
        {
            var message =
                "Airway Schedule Bot commands:\n\n" +
                "/plane [plane_name] - Get plane info for specified plane model\n\n" +
                "Commands that allow you to get flight schedule from departure point to destination point on specified date:\n\n" +
                "/iata [departure destination date] - Departure and destination points should be specified as IATA codes\n" +
                "/city [departure destination date] - Departure and destination points should be specified as city name in international format\n" +
                "/airport [departure destination date] - Departure and destination points should be specified as airport name in international format\n";

            await _telegramBotClient.SendTextMessageAsync(chatId, message);
        }
    }
}
