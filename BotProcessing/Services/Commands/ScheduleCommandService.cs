// <copyright file="ScheduleCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    using Telegram.Bot;

    using Common.Exceptions;

    using Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;
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

            var responseMessage = BuildResponseMessage(responseModel);

            await _telegramBotClient.SendTextMessageAsync(chatId, responseMessage, disableWebPagePreview: true);
        }

        private string BuildResponseMessage(YandexApiResponse responseModel)
        {
            var response = new StringBuilder();
            var segments = responseModel.Segments;

            foreach (var segment in segments)
            {
                response.Append(
                    $"Flight: {segment.Thread.Title}\n" +
                    $"Flight number: {segment.Thread.Number}\n" +
                    $"Departure: {segment.DeparturePoint.Title}\n" +
                    $"Arrival: {segment.ArrivalPoint.Title}\n" +
                    $"Departure date: {segment.Departure.ToShortDateString() + " " + segment.Departure.ToShortTimeString()}\n" +
                    $"Arrival date: {segment.Arrival.ToShortDateString() + " " + segment.Arrival.ToShortTimeString()}\n" +
                    $"Airline: {segment.Thread.Carrier.Title}\n" +
                    $"Site: {segment.Thread.Carrier.Url}\n" +
                    $"Plane: {segment.Thread.Vehicle}");

                response.AppendLine();
                response.AppendLine();
            }

            return response.ToString();
        }
    }
}
