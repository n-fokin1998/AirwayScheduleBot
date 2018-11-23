// <copyright file="FilterPipelineBuilder.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Filter
{
    using AirwaySchedule.Bot.Data.FilterModels;
    using AirwaySchedule.Bot.DataAccess.Filter.Filters;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;

    /// <summary>
    /// FilterPipelineBuilder
    /// </summary>
    public class FilterPipelineBuilder : IFilterPipelineBuilder
    {
        private readonly IFilterPipeline _filterPipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterPipelineBuilder"/> class.
        /// </summary>
        public FilterPipelineBuilder()
        {
            _filterPipeline = new FilterPipeline();
        }

        /// <summary>
        /// AddPagingFilter
        /// </summary>
        /// <param name="pagingInfo">pagingInfo</param>
        public void AddPagingFilter(PagingInfo pagingInfo)
        {
            _filterPipeline.Add(new PagingFilter(pagingInfo));
        }

        /// <summary>
        /// AddSearchFilter
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        public void AddSearchFilter(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                _filterPipeline.Add(new SearchFilter(searchKey.ToLower()));
            }
        }

        /// <summary>
        /// GetFilterPipeline
        /// </summary>
        /// <returns>IFilterPipeline</returns>
        public IFilterPipeline GetFilterPipeline()
        {
            return _filterPipeline;
        }
    }
}
