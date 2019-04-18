// <copyright file="Command.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Models
{
    /// <summary>
    /// Command
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Command text.
        /// </summary>
        public string Text { get; set; }
    }
}
