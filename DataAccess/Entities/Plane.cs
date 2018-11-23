// <copyright file="Plane.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Entities
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// Plane
    /// </summary>
    public class Plane
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// PlaneId
        /// </summary>
        [BsonElement("planeId")]
        public int PlaneId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Seats
        /// </summary>
        [BsonElement("seats")]
        public string Seats { get; set; }

        /// <summary>
        /// Range
        /// </summary>
        [BsonElement("range")]
        public string Range { get; set; }

        /// <summary>
        /// Speed
        /// </summary>
        [BsonElement("speed")]
        public string Speed { get; set; }
    }
}
