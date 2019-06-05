// <copyright file="PlaneDetailsCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System.Threading.Tasks;

    using Telegram.Bot;

    using Common.Exceptions;
    using Interfaces.Services.Commands;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.BotProcessing.Models;
    using AirwaySchedule.Bot.DataAccess.Interfaces;

    /// <summary>
    /// PlaneDetailsCommandService
    /// </summary>
    public class PlaneDetailsCommandService : IPlaneDetailsCommandService
    {
        private const string PlaneNotFoundErrorMessage = "😢 Plane not found";

        private readonly IPlaneRepository _planeRepository;
        private readonly ITelegramBotClient _telegramBotClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneDetailsCommandService"/> class.
        /// </summary>
        /// <param name="planeRepository">planeRepository</param>
        /// <param name="telegramBotClient">telegramBotClient</param>
        public PlaneDetailsCommandService(IPlaneRepository planeRepository, ITelegramBotClient telegramBotClient)
        {
            _planeRepository = planeRepository;
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
            var responseModel = _planeRepository.GetByName(command.Text);

            if (responseModel == null)
            {
                throw new BotCommandException(chatId, PlaneNotFoundErrorMessage);
            }

            var responseMessage = BuildResponseMessage(responseModel);

            await _telegramBotClient.SendTextMessageAsync(chatId, responseMessage);
        }

        private string BuildResponseMessage(Plane responseModel)
        {
            var response = $"⭐ Model: {responseModel.Name}\n" +
                           $"  Number of seats: {responseModel.Seats}\n" +
                           $"  Speed: {responseModel.Speed} km/h.\n" +
                           $"  Range of flight: {responseModel.Range} km.";

            return response;
        }
    }
}
