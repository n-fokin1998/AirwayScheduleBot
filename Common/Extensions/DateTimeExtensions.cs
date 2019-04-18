// <copyright file="DateTimeExtensions.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Common.Extensions
{
    using System;

    /// <summary>
    /// DateTimeExtensions
    /// </summary>
    public static class DateTimeExtensions
    {
        private const string IsoDateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Gate DateTime string in ISO format
        /// </summary>
        /// <param name="date">date</param>
        /// <returns>Date time string in ISO format.</returns>
        public static string ToIsoString(this DateTime date)
        {
            return date.ToString(IsoDateFormat);
        }
    }
}
