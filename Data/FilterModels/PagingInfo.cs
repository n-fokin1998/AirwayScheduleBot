// <copyright file="PagingInfo.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Data.FilterModels
{
    using System;
    using AirwaySchedule.Bot.Data.Utils;

    /// <summary>
    /// PagingInfo
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Skip
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Top
        /// </summary>
        public int Top { get; set; } = GlobalParameters.DefaultPageSize;

        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// TotalPages
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / Top);
    }
}
