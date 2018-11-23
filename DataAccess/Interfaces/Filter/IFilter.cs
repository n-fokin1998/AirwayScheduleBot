// <copyright file="IFilter.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces.Filter
{
    using System.Linq;
    using AirwaySchedule.Bot.DataAccess.Entities;

    /// <summary>
    /// Filter interface
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Apply method
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Plane queryable</returns>
        IQueryable<Plane> Apply(IQueryable<Plane> input);
    }
}
