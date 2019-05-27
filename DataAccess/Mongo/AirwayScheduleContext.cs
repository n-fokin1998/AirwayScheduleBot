// <copyright file="AirwayScheduleContext.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Mongo
{
    using System;
    using System.Linq;

    using MongoDB.Driver;

    using AirwaySchedule.Bot.DataAccess.Entities;

    /// <summary>
    /// AirwayScheduleContext
    /// </summary>
    public class AirwayScheduleContext
    {
        private const string PlanesCollectionName = "planes";
        private const string UsersCollectionName = "users";

        private readonly Lazy<IMongoCollection<Plane>> _planesCollection;
        private readonly Lazy<IMongoCollection<User>> _usersCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirwayScheduleContext"/> class.
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        public AirwayScheduleContext(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(connection.DatabaseName);

            _planesCollection = new Lazy<IMongoCollection<Plane>>(
                () => database.GetCollection<Plane>(PlanesCollectionName));
            _usersCollection = new Lazy<IMongoCollection<User>>(
                () => database.GetCollection<User>(UsersCollectionName));
        }

        /// <summary>
        /// Planes
        /// </summary>
        public IMongoCollection<Plane> Planes => _planesCollection.Value;

        /// <summary>
        /// Users
        /// </summary>
        public IMongoCollection<User> Users => _usersCollection.Value;
    }
}
