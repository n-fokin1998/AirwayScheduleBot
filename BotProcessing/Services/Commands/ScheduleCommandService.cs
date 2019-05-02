// <copyright file="ScheduleCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Threading.Tasks;

    using Telegram.Bot;
    using Telegram.Bot.Types.ReplyMarkups;

    using Common.Exceptions;

    using Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;
    using AirwaySchedule.Bot.Common.Utils;

    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using IntegrationProxy.Contracts.YandexApi;
    using Interfaces.Infrastructure.ScheduleRequestCreator;

    /// <summary>
    /// ScheduleCommandService
    /// </summary>
    public class ScheduleCommandService : IScheduleCommandService
    {
        private const string ApiErrorMessage = "Something went wrong";

        private readonly IYandexApiProxy _yandexApiProxy;
        private readonly IScheduleRequestCreator _requestCreator;
        private readonly ITelegramBotClient _telegramBotClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleCommandService"/> class.
        /// </summary>
        /// <param name="yandexApiProxy">yandexApiProxy</param>
        /// <param name="requestCreator">requestCreator</param>
        /// <param name="telegramBotClient">telegramBotClient</param>
        public ScheduleCommandService(
            IYandexApiProxy yandexApiProxy,
            IScheduleRequestCreator requestCreator,
            ITelegramBotClient telegramBotClient)
        {
            _yandexApiProxy = yandexApiProxy;
            _requestCreator = requestCreator;
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
            var requestModel = await _requestCreator.CreateRequest(chatId, command);

            YandexApiResponse responseModel;
            try
            {
                responseModel = await _yandexApiProxy.GetResponseAsync(requestModel);
            }
            catch (Exception)
            {
                throw new BotCommandException(chatId, ApiErrorMessage);
            }

            await SendResponse(chatId, responseModel);
        }

        private async Task SendResponse(long chatId, YandexApiResponse responseModel)
        {
            foreach (var segment in responseModel.Segments)
            {
                var res =
                    $"Flight: {segment.Thread.Title}\n" +
                    $"Flight number: {segment.Thread.Number}\n" +
                    $"Departure: {segment.DeparturePoint.Title}\n" +
                    $"Arrival: {segment.ArrivalPoint.Title}\n" +
                    $"Departure date: {segment.Departure.ToShortDateString() + " " + segment.Departure.ToShortTimeString()}\n" +
                    $"Arrival date: {segment.Arrival.ToShortDateString() + " " + segment.Arrival.ToShortTimeString()}\n" +
                    $"Airline: {segment.Thread.Carrier.Title}\n" +
                    $"Site: {segment.Thread.Carrier.Url}\n" +
                    $"Plane: {segment.Thread.Vehicle}";

                await _telegramBotClient.SendTextMessageAsync(
                    chatId,
                    res,
                    disableWebPagePreview: true,
                    replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton
                    {
                        Text = "Plane info",
                        CallbackData = $"{CommandNames.PlaneDetailsCommand} {segment.Thread.Vehicle}"
                    }));
            }
        }
    }
}
