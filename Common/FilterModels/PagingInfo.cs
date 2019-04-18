// <copyright file="PagingInfo.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Common.FilterModels
{
    using System;
    using Common.Utils;

    /// <summary>
    /// PagingInfo
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// PageNumber
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = GlobalParameters.DefaultPageSize;

        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// TotalPages
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / PageSize);
    }
}
