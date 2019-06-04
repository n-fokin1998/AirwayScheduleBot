// <copyright file="EmailSenderConfiguration.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Common.Models
{
    /// <summary>
    /// EmailSenderConfiguration
    /// </summary>
    public class EmailSenderConfiguration
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public string Port { get; set; }
    }
}
