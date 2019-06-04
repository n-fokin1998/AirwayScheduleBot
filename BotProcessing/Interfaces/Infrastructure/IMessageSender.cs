// <copyright file="IMessageSender.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure
{
    using System.Net.Mail;

    /// <summary>
    /// IMessageSender
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message">message</param>
        void Send(MailMessage message);
    }
}
