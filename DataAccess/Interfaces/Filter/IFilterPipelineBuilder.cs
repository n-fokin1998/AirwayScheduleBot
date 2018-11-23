// <copyright file="IFilterPipelineBuilder.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces.Filter
{
    using AirwaySchedule.Bot.Data.FilterModels;

    /// <summary>
    /// IFilterPipelineBuilder
    /// </summary>
    public interface IFilterPipelineBuilder
    {
        /// <summary>
        /// GetFilterPipeline
        /// </summary>
        /// <returns>IFilterPipeline</returns>
        IFilterPipeline GetFilterPipeline();

        /// <summary>
        /// AddSearchFilter
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        void AddSearchFilter(string searchKey);

        /// <summary>
        /// AddPagingFilter
        /// </summary>
        /// <param name="pagingInfo">pagingInfo</param>
        void AddPagingFilter(PagingInfo pagingInfo);
    }
}
