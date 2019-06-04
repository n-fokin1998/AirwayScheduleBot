// <copyright file="IEmailService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure
{
    using AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi;

    /// <summary>
    /// IEmailService
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// SendScheduleLetter
        /// </summary>
        /// <param name="responseModel">responseModel</param>
        /// <param name="email">email</param>
        void SendScheduleLetter(YandexApiResponse responseModel, string email);
    }
}
