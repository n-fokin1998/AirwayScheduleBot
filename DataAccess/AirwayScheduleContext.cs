// <copyright file="AirwayScheduleContext.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess
{
    using System;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using MongoDB.Driver;

    /// <summary>
    /// AirwayScheduleContext
    /// </summary>
    public class AirwayScheduleContext
    {
        private const string PlanesCollectionName = "planes";

        private readonly Lazy<IMongoCollection<Plane>> _planesCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirwayScheduleContext"/> class.
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        public AirwayScheduleContext(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connection.DatabaseName);

            _planesCollection = new Lazy<IMongoCollection<Plane>>(() => database.GetCollection<Plane>(PlanesCollectionName));
        }

        /// <summary>
        /// Planes
        /// </summary>
        public IMongoCollection<Plane> Planes => _planesCollection.Value;
    }
}
