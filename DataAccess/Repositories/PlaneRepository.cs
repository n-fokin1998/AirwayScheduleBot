// <copyright file="PlaneRepository.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AirwaySchedule.Bot.Common.FilterModels;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// PlaneRepository
    /// </summary>
    public class PlaneRepository : IPlaneRepository
    {
        private readonly AirwayScheduleContext _context;
        private readonly IFilterPipelineBuilder _filterPipelineBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneRepository"/> class.
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="filterPipelineBuilder">filterPipelineBuilder</param>
        public PlaneRepository(AirwayScheduleContext context, IFilterPipelineBuilder filterPipelineBuilder)
        {
            _context = context;
            _filterPipelineBuilder = filterPipelineBuilder;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">item</param>
        public void Add(Plane item)
        {
            _context.Planes.InsertOne(item);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="item">item</param>
        public void Edit(Plane item)
        {
            _context.Planes.ReplaceOne(new BsonDocument("_id", new ObjectId(item.Id)), item);
        }

        /// <summary>
        /// FindByName
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Plane</returns>
        public Plane FindByName(string name)
        {
            var plane = _context.Planes.AsQueryable()
                .FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));

            return plane;
        }

        /// <summary>
        /// GetFilteredList
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <param name="pagingInfo">pagingInfo</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Plane> GetFilteredList(string searchKey, PagingInfo pagingInfo)
        {
            var filterPipeline = BuildFilterPipeline(searchKey, pagingInfo);
            var planes = _context.Planes.AsQueryable();

            return filterPipeline.Execute(planes).ToList();
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id">id</param>
        public void Remove(string id)
        {
            _context.Planes.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
        }

        private IFilterPipeline BuildFilterPipeline(string searchKey, PagingInfo pagingInfo)
        {
            _filterPipelineBuilder.AddSearchFilter(searchKey);
            _filterPipelineBuilder.AddPagingFilter(pagingInfo);

            return _filterPipelineBuilder.GetFilterPipeline();
        }
    }
}
