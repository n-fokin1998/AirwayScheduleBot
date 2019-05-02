// <copyright file="PlaneRepository.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Repositories
{
    using System;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver;

    using AirwaySchedule.Bot.DataAccess.Mongo;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Interfaces;

    /// <summary>
    /// PlaneRepository
    /// </summary>
    public class PlaneRepository : IPlaneRepository
    {
        private readonly AirwayScheduleContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaneRepository"/> class.
        /// </summary>
        /// <param name="context">context</param>
        public PlaneRepository(AirwayScheduleContext context)
        {
            _context = context;
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
        /// Remove
        /// </summary>
        /// <param name="id">id</param>
        public void Remove(string id)
        {
            _context.Planes.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
