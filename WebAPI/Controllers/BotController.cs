// <copyright file="BotController.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Controllers
{
    using AirwaySchedule.Bot.BotProcessing.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    /// <summary>
    /// BotController
    /// </summary>
    [Route("api/[controller]")]
    public class BotController : Controller
    {
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
        [HttpPost]
        public void Update([FromBody]Update update)
        {
            if (update != null && update.Message.Type == MessageType.Text)
            {
                _commandInvokerService.ExecuteCommand(update.Message.Chat.Id, update.Message.Text);
            }
        }
    }
}
