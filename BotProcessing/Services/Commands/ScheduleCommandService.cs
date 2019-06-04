// <copyright file="ScheduleCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Memory;

    using Telegram.Bot;
    using Telegram.Bot.Types.ReplyMarkups;

    using Common.Exceptions;

    using Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;
    using AirwaySchedule.Bot.Common.Utils;

    using AirwaySchedule.Bot.Common.Extensions;
    using AirwaySchedule.Bot.Common.Models;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using IntegrationProxy.Contracts.YandexApi;
    using Interfaces.Infrastructure.ScheduleRequestCreator;

    /// <summary>
    /// ScheduleCommandService
    /// </summary>
    public class ScheduleCommandService : IScheduleCommandService
    {
        private const int CacheExpirationTime = 5;
        private const string ApiErrorMessage = "Something went wrong";

        private readonly IYandexApiProxy _yandexApiProxy;
        private readonly IScheduleRequestCreator _requestCreator;
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleCommandService"/> class.
        /// </summary>
        /// <param name="yandexApiProxy">yandexApiProxy</param>
        /// <param name="requestCreator">requestCreator</param>
        /// <param name="telegramBotClient">telegramBotClient</param>
        /// <param name="memoryCache">memoryCache</param>
        public ScheduleCommandService(
            IYandexApiProxy yandexApiProxy,
            IScheduleRequestCreator requestCreator,
            ITelegramBotClient telegramBotClient,
            IMemoryCache memoryCache)
        {
            _yandexApiProxy = yandexApiProxy;
            _requestCreator = requestCreator;
            _telegramBotClient = telegramBotClient;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>Task</returns>
        public async Task ExecuteAsync(long chatId, Command command)
        {
            var requestModel = await _requestCreator.CreateRequest(chatId, command);

            YandexApiResponse responseModel;
            try
            {
                responseModel = await _yandexApiProxy.GetResponseAsync(requestModel);

                _memoryCache.Set(
                    chatId,
                    responseModel,
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheExpirationTime)
                    });
            }
            catch (Exception)
            {
                throw new BotCommandException(chatId, ApiErrorMessage);
            }

            await SendResponse(chatId, requestModel, responseModel);
        }

        private async Task SendResponse(
            long chatId,
            RequestParameters requestModel,
            YandexApiResponse responseModel)
        {
            foreach (var segment in responseModel.Segments)
            {
                var message =
                    $"Flight: {segment.Thread.Title}\n" +
                    $"Flight number: {segment.Thread.Number}\n" +
                    $"Departure: {segment.DeparturePoint.Title}\n" +
                    $"Arrival: {segment.ArrivalPoint.Title}\n" +
                    $"Departure date: {segment.Departure.ToShortDateString() + " " + segment.Departure.ToShortTimeString()}\n" +
                    $"Arrival date: {segment.Arrival.ToShortDateString() + " " + segment.Arrival.ToShortTimeString()}\n" +
                    $"Airline: {segment.Thread.Carrier.Title}\n" +
                    $"Site: {segment.Thread.Carrier.Url}\n" +
                    $"Plane: {segment.Thread.Vehicle}";

                var markupButtons = new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton
                    {
                        Text = "Plane info",
                        CallbackData = $"{CommandNames.PlaneDetailsCommand} {segment.Thread.Vehicle}"
                    }
                };

                if (responseModel.Segments.Last() == segment)
                {
                    markupButtons.Add(new InlineKeyboardButton
                    {
                        Text = "Send results by email",
                        CallbackData =
                            $"{CommandNames.SendByEmailCommand} {requestModel.Departure} {requestModel.Destination} {requestModel.Date.ToIsoString()}"
                    });
                }

                await _telegramBotClient.SendTextMessageAsync(
                    chatId,
                    message,
                    disableWebPagePreview: true,
                    replyMarkup: new InlineKeyboardMarkup(markupButtons));
            }
        }
    }
}
