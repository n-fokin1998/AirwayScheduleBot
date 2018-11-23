// <copyright file="PagingFilter.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Filter.Filters
{
    using System.Linq;
    using AirwaySchedule.Bot.Data.FilterModels;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;

    /// <summary>
    /// PagingFilter
    /// </summary>
    public class PagingFilter : IFilter
    {
        private readonly PagingInfo _pagingInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingFilter"/> class.
        /// </summary>
        /// <param name="pagingInfo">pagingInfo</param>
        public PagingFilter(PagingInfo pagingInfo)
        {
            _pagingInfo = pagingInfo;
        }

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Plane> Apply(IQueryable<Plane> input)
        {
            _pagingInfo.TotalCount = input.Count();
            var result = input.Skip(_pagingInfo.Skip).Take(_pagingInfo.Top);

            return result;
        }
    }
}
