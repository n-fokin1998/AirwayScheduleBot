// <copyright file="SetEmailCommandService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Services.Commands
{
    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Telegram.Bot;

    using AirwaySchedule.Bot.BotProcessing.Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Models;
    using AirwaySchedule.Bot.Common.Exceptions;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces;

    /// <summary>
    /// SetEmailCommandService
    /// </summary>
    public class SetEmailCommandService : ISetEmailCommandService
    {
        private const string EmailNotValidErrorMessage = "Email not valid!";

        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetEmailCommandService"/> class.
        /// </summary>
        /// <param name="telegramBotClient">telegramBotClient</param>
        /// <param name="userRepository">userRepository</param>
        public SetEmailCommandService(ITelegramBotClient telegramBotClient, IUserRepository userRepository)
        {
            _telegramBotClient = telegramBotClient;
            _userRepository = userRepository;
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="chatId">chatId</param>
        /// <param name="command">command</param>
        /// <returns>Task</returns>
        public async Task ExecuteAsync(long chatId, Command command)
        {
            if (!IsValidEmail(command.Text))
            {
                throw new BotCommandException(chatId, EmailNotValidErrorMessage);
            }

            var user = _userRepository.GetById(chatId);

            if (user != null)
            {
                user.Email = command.Text;

                _userRepository.Edit(user);
            }
            else
            {
                _userRepository.Add(new User
                {
                    UserId = chatId,
                    Email = command.Text
                });
            }

            await _telegramBotClient.SendTextMessageAsync(chatId, "Email successfully set");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
