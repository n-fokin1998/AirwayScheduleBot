// <copyright file="SearchFilter.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Filter.Filters
{
    using System.Linq;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;

    /// <summary>
    /// SearchFilter
    /// </summary>
    public class SearchFilter : IFilter
    {
        private readonly string _searchKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFilter"/> class.
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        public SearchFilter(string searchKey)
        {
            _searchKey = searchKey;
        }

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Plane> Apply(IQueryable<Plane> input)
        {
            return input.Where(x => x.Name.ToLower().Contains(_searchKey));
        }
    }
}
