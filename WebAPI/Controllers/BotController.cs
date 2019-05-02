// <copyright file="BotController.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    using BotProcessing.Interfaces.Services;

    /// <summary>
    /// BotController
    /// </summary>
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        private readonly ICommandInvokerService _commandInvokerService;
        private readonly ITelegramBotClient _botClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BotController"/> class.
        /// </summary>
        /// <param name="commandInvokerService">commandInvokerService</param>
        /// <param name="botClient">botClient</param>
        public BotController(ICommandInvokerService commandInvokerService, ITelegramBotClient botClient)
        {
            _commandInvokerService = commandInvokerService;
            _botClient = botClient;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="update">update</param>
        /// <returns>Task</returns>
        [HttpPost("update")]
        public async Task Update([FromBody]Update update)
        {
            if (update != null && (update.CallbackQuery != null || update.Message.Type == MessageType.Text))
            {
                var chatId = update.CallbackQuery?.Message.Chat.Id ?? update.Message.Chat.Id;
                var messageText = update.CallbackQuery?.Data ?? update.Message.Text;

                try
                {
                    await _commandInvokerService.ExecuteCommandAsync(chatId, messageText);
                }
                catch
                {
                }
            }
        }
    }
}
