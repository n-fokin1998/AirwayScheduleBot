// <copyright file="IUnitOfWork.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Interfaces
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Planes
        /// </summary>
        IPlaneRepository Planes { get; }
    }
}
