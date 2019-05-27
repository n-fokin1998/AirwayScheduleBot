// <copyright file="IUserRepository.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces
{
    using AirwaySchedule.Bot.DataAccess.Entities;

    /// <summary>
    /// IUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>User</returns>
        User GetById(long userId);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item">item</param>
        void Add(User item);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="item">item</param>
        void Edit(User item);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id">id</param>
        void Remove(string id);
    }
}
