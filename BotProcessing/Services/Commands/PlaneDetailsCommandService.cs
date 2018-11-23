// <copyright file="PlaneDetailsCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System.Threading.Tasks;
    using AirwaySchedule.Bot.BotProcessing.Infrastructure;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Commands;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using Telegram.Bot;

    /// <summary>
    /// PlaneDetailsCommandService
    /// </summary>
    public class PlaneDetailsCommandService : IPlaneDetailsCommandService
    {
        private const string PlaneNotFoundErrorMessage = "Самолёт не найден";

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITelegramBotClient _telegramBotClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneDetailsCommandService"/> class.
        /// </summary>
        /// <param name="unitOfWork">unitOfWork</param>
        /// <param name="telegramBotClient">telegramBotClient</param>
        public PlaneDetailsCommandService(IUnitOfWork unitOfWork, ITelegramBotClient telegramBotClient)
        {
            _unitOfWork = unitOfWork;
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
            var responseModel = _unitOfWork.Planes.FindByName(commandText);

            if (responseModel == null)
            {
                throw new BotCommandException(chatId, PlaneNotFoundErrorMessage);
            }

            await _telegramBotClient.SendTextMessageAsync(chatId, BuildResponseBody(responseModel));
        }

        private string BuildResponseBody(Plane responseModel)
        {
            var response = $"Модель: {responseModel.Name}\n" +
                           $"Количество мест: {responseModel.Seats}\n" +
                           $"Крейсерская скорость: {responseModel.Seats}\n" +
                           $"Дальность полёта: {responseModel.Range}";

            return response;
        }
    }
}
