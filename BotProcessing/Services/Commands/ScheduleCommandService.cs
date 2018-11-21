// <copyright file="ScheduleCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using AirwaySchedule.Bot.BotProcessing.Extensions;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Commands;
    using AirwaySchedule.Bot.Data.Dto;
    using Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces;
    using AirwaySchedule.Bot.IntegrationProxy.Models.Response;
    using Telegram.Bot;

    /// <summary>
    /// ScheduleCommandService
    /// </summary>
    public class ScheduleCommandService : IScheduleCommandService
    {
        private const string DateFormatErrorMessage = "Неверный формат даты";
        private const string CommandFormatErrorMessage = "Команда введена неверно";
        private const string ApiErrorMessage = "Произошла ошибка сервера";

        private readonly IYandexApiProxy _yandexApiProxy;
        private readonly ITelegramBotClient _telegramBotClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleCommandService"/> class.
        /// </summary>
        /// <param name="yandexApiProxy">yandexApiProxy</param>
        /// <param name="telegramBotClient">telegramBotClient</param>
        public ScheduleCommandService(IYandexApiProxy yandexApiProxy, ITelegramBotClient telegramBotClient)
        {
            _yandexApiProxy = yandexApiProxy;
            _telegramBotClient = telegramBotClient;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="commandText">commandText</param>
        /// <returns>Task</returns>
        public async Task ExecuteAsync(long chatId, string commandText)
        {
            var requestParameters = commandText.GetCommandParameters();

            if (requestParameters.Length < 3)
            {
                throw new BotCommandException(chatId, CommandFormatErrorMessage);
            }

            var requestParametersDto = new RequestParametersDto
            {
                Departure = requestParameters[0],
                Destination = requestParameters[1]
            };

            if (!DateTime.TryParse(requestParameters[2], out var result))
            {
                throw new BotCommandException(chatId, DateFormatErrorMessage);
            }

            requestParametersDto.DateFrom = result;

            ApiResponse responseModel;
            try
            {
                responseModel = await _yandexApiProxy.GetResponseAsync(requestParametersDto);
            }
            catch (Exception)
            {
                throw new BotCommandException(chatId, ApiErrorMessage);
            }

            await _telegramBotClient.SendTextMessageAsync(chatId, BuildResponseBody(responseModel));
        }

        private string BuildResponseBody(ApiResponse responseModel)
        {
            var response = new StringBuilder();
            var segments = responseModel.Segments;

            foreach (var segment in segments)
            {
                response.Append(
                    $"Рейс: {segment.Thread.Title}\n" +
                    $"Номер рейса: {segment.Thread.Number}\n" +
                    $"Вылет из: {segment.DeparturePoint.Title}\n" +
                    $"Прибытие в: {segment.ArrivalPoint.Title}\n" +
                    $"Дата вылета: {segment.Departure.ToShortDateString() + " " + segment.Departure.ToShortTimeString()}\n" +
                    $"Дата прибытия: {segment.Arrival.ToShortDateString() + " " + segment.Arrival.ToShortTimeString()}\n" +
                    $"Авиакомпания: {segment.Thread.Carrier.Title}\n" +
                    $"Сайт: {segment.Thread.Carrier.Url}\n" +
                    $"Самолёт: {segment.Thread.Vehicle}");

                if (segments.FindIndex(x => x == segment) == segments.Count - 1)
                {
                    response.Append("\n\n");
                }
            }

            return response.ToString();
        }
    }
}
