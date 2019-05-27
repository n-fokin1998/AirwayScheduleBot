// <copyright file="UserRepository.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Repositories
{
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver;

    using AirwaySchedule.Bot.DataAccess.Entities;
    using AirwaySchedule.Bot.DataAccess.Mongo;
    using AirwaySchedule.Bot.DataAccess.Interfaces;

    /// <summary>
    /// UserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AirwayScheduleContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">context</param>
        public UserRepository(AirwayScheduleContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">item</param>
        public void Add(User item)
        {
            _context.Users.InsertOne(item);
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="item">item</param>
        public void Edit(User item)
        {
            _context.Users.ReplaceOne(new BsonDocument("_id", new ObjectId(item.Id)), item);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>User</returns>
        public User GetById(long userId)
        {
            var user = _context.Users.AsQueryable()
                .FirstOrDefault(x => x.UserId == userId);

            return user;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id">id</param>
        public void Remove(string id)
        {
            _context.Users.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
        }
    }
}
