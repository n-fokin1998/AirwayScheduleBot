// <copyright file="IFilterPipeline.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces.Filter
{
    using System.Linq;
    using AirwaySchedule.Bot.DataAccess.Entities;

    /// <summary>
    /// IFilterPipeline
    /// </summary>
    public interface IFilterPipeline
    {
        /// <summary>
        /// Adds filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>Filter pipeline</returns>
        IFilterPipeline Add(IFilter filter);

        /// <summary>
        /// Executes filter pipeline
        /// </summary>
        /// <param name="planes">planes</param>
        /// <returns>Planes queryable</returns>
        IQueryable<Plane> Execute(IQueryable<Plane> planes);
    }
}
