// <copyright file="MessageSender.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure
{
    using System.Net;
    using System.Net.Mail;

    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.Common.Models;

    /// <summary>
    /// MessageSender
    /// </summary>
    public class MessageSender : IMessageSender
    {
        private readonly EmailSenderConfiguration _emailSenderConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageSender"/> class.
        /// </summary>
        /// <param name="emailSenderConfiguration">emailSenderConfiguration</param>
        public MessageSender(EmailSenderConfiguration emailSenderConfiguration)
        {
            _emailSenderConfiguration = emailSenderConfiguration;
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="message">message</param>
        public void Send(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _emailSenderConfiguration.Email,
                    Password = _emailSenderConfiguration.Password
                };

                client.Credentials = credential;
                client.Host = _emailSenderConfiguration.Host;
                client.Port = int.Parse(_emailSenderConfiguration.Port);
                client.EnableSsl = true;

                client.Send(message);
            }
        }
    }
}
