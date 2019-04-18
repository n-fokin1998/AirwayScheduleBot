// <copyright file="ServiceExceptionFilterAttribute.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Filters
{
    using System.Threading.Tasks;
    using Common.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Telegram.Bot;

    /// <summary>
    /// ServiceExceptionFilterAttribute
    /// </summary>
    public class ServiceExceptionFilterAttribute : IAsyncExceptionFilter
    {
        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>Task</returns>
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception is BotCommandException serviceException)
            {
                var telegramBotClient =
                    (ITelegramBotClient)context.HttpContext.RequestServices.GetService(typeof(ITelegramBotClient));

                await telegramBotClient.SendTextMessageAsync(serviceException.ChatId, serviceException.Message);

                context.Result = new OkResult();
            }
        }
    }
}
