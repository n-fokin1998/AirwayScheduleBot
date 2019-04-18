// <copyright file="IPlaneRepository.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces
{
    using System.Collections.Generic;
    using AirwaySchedule.Bot.Common.FilterModels;
    using AirwaySchedule.Bot.DataAccess.Entities;

    /// <summary>
    /// IPlaneRepository
    /// </summary>
    public interface IPlaneRepository
    {
        /// <summary>
        /// GetFilteredList
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <param name="pagingInfo">pagingInfo</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<Plane> GetFilteredList(string searchKey, PagingInfo pagingInfo);

        /// <summary>
        /// FindByName
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Plane</returns>
        Plane FindByName(string name);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">item</param>
        void Add(Plane item);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="item">item</param>
        void Edit(Plane item);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id">id</param>
        void Remove(string id);
    }
}
