// <copyright file="User.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Entities
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [BsonElement("userId")]
        public long UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
