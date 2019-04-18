// <copyright file="IPlaneService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.AdminPanelProcessing.Interfaces
{
    using System.Collections.Generic;
    using Common.Models;
    using AirwaySchedule.Bot.Common.FilterModels;

    /// <summary>
    /// IPlaneService
    /// </summary>
    public interface IPlaneService
    {
        /// <summary>
        /// GetFilteredPlanes
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <param name="pagingInfo">pagingInfo</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<Plane> GetFilteredPlanes(string searchKey, PagingInfo pagingInfo);
    }
}
