// <copyright file="SendByEmailCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Memory;

    using Telegram.Bot;

    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.Common.Exceptions;
    using AirwaySchedule.Bot.Common.Utils;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure.ScheduleRequestCreator;
    using AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;

    /// <summary>
    /// SendByEmailCommandService
    /// </summary>
    public class SendByEmailCommandService : ISendByEmailCommandService
    {
        private const string ApiErrorMessage = "😢 Something went wrong";
        private const string SendEmailErrorMessage = "😢 Failed to send email";
        private const string EmailNotFoundErrorMessage = "❗ Email not set. Use /setemail command to set your email.";

        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IYandexApiProxy _yandexApiProxy;
        private readonly IScheduleRequestCreator _requestCreator;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendByEmailCommandService"/> class.
        /// </summary>
        /// <param name="telegramBotClient">telegramBotClient</param>
        /// <param name="userRepository">userRepository</param>
        /// <param name="memoryCache">memoryCache</param>
        /// <param name="yandexApiProxy">yandexApiProxy</param>
        /// <param name="requestCreator">requestCreator</param>
        /// <param name="emailService">emailService</param>
        public SendByEmailCommandService(
            ITelegramBotClient telegramBotClient,
            IUserRepository userRepository,
            IMemoryCache memoryCache,
            IYandexApiProxy yandexApiProxy,
            IScheduleRequestCreator requestCreator,
            IEmailService emailService)
        {
            _telegramBotClient = telegramBotClient;
            _userRepository = userRepository;
            _memoryCache = memoryCache;
            _yandexApiProxy = yandexApiProxy;
            _requestCreator = requestCreator;
            _emailService = emailService;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>Task</returns>
        public async Task ExecuteAsync(long chatId, Command command)
        {
            _memoryCache.TryGetValue(chatId, out YandexApiResponse responseModel);

            if (responseModel == null)
            {
                command.Name = CommandNames.ScheduleByIataCommand;

                var request = await _requestCreator.CreateRequest(chatId, command);

                try
                {
                    responseModel = await _yandexApiProxy.GetResponseAsync(request);
                }
                catch (Exception)
                {
                    throw new BotCommandException(chatId, ApiErrorMessage);
                }
            }

            var user = _userRepository.GetById(chatId);

            if (user == null)
            {
                throw new BotCommandException(chatId, EmailNotFoundErrorMessage);
            }

            try
            {
                _emailService.SendScheduleLetter(responseModel, user.Email);
            }
            catch (Exception)
            {
                throw new BotCommandException(chatId, SendEmailErrorMessage);
            }

            await _telegramBotClient.SendTextMessageAsync(chatId, "✅ Email successfully sent.");
        }
    }
}
