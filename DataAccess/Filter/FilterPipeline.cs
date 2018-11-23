// <copyright file="FilterPipeline.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Filter
{
    using System.Collections.Generic;
    using System.Linq;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;

    /// <summary>
    /// FilterPipeline
    /// </summary>
    public class FilterPipeline : IFilterPipeline
    {
        private readonly List<IFilter> _filters;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterPipeline"/> class.
        /// </summary>
        public FilterPipeline()
        {
            _filters = new List<IFilter>();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>IFilterPipeline</returns>
        public IFilterPipeline Add(IFilter filter)
        {
            _filters.Add(filter);

            return this;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="planes">planes</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Plane> Execute(IQueryable<Plane> planes)
        {
            planes = _filters.Aggregate(planes, (current, filter) => filter.Apply(current));

            return planes;
        }
    }
}
