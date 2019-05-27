// <copyright file="BotController.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    using BotProcessing.Interfaces.Services;

    /// <summary>
    /// BotController
    /// </summary>
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        private static int _updateId;
        private readonly ICommandInvokerService _commandInvokerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BotController"/> class.
        /// </summary>
        /// <param name="commandInvokerService">commandInvokerService</param>
        public BotController(ICommandInvokerService commandInvokerService)
        {
            _commandInvokerService = commandInvokerService;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="update">update</param>
        /// <returns>Task</returns>
        [HttpPost("update")]
        public async Task Update([FromBody]Update update)
        {
            if (update == null || update.Id == _updateId)
            {
                return;
            }

            _updateId = update.Id;

            if (update.CallbackQuery != null || update.Message.Type == MessageType.Text)
            {
                var chatId = update.CallbackQuery?.Message.Chat.Id ?? update.Message.Chat.Id;
                var messageText = update.CallbackQuery?.Data ?? update.Message.Text;

                await _commandInvokerService.ExecuteCommandAsync(chatId, messageText);
            }
        }
    }
}
