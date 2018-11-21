// <copyright file="BotMessageExtensions.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Extensions
{
    /// <summary>
    /// BotMessageExtensions
    /// </summary>
    public static class BotMessageExtensions
    {
        /// <summary>
        /// GetCommandName
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>string</returns>
        public static string GetCommandName(this string message)
        {
            return message.Substring(0, message.IndexOf(' '));
        }

        /// <summary>
        /// GetCommandText
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>string</returns>
        public static string GetCommandText(this string message)
        {
            return message.Substring(message.IndexOf(' '));
        }

        /// <summary>
        /// GetCommandParameters
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>string array</returns>
        public static string[] GetCommandParameters(this string message)
        {
            return message.Replace(" ", string.Empty).Split(',');
        }
    }
}
