// <copyright file="BotCommandException.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure
{
    using System;

    /// <summary>
    /// BotCommandException
    /// </summary>
    public class BotCommandException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BotCommandException"/> class.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="chatId">chatId</param>
        public BotCommandException(long chatId, string message)
            : base(message)
        {
            Message = message;
            ChatId = chatId;
        }

        /// <summary>
        /// Message
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// ChatId
        /// </summary>
        public long ChatId { get; set; }
    }
}
