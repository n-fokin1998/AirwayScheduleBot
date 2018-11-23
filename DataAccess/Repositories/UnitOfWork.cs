// <copyright file="UnitOfWork.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.DataAccess.Repositories
{
    using AirwaySchedule.Bot.DataAccess.Interfaces;

    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="planeRepository">planeRepository</param>
        public UnitOfWork(IPlaneRepository planeRepository)
        {
            Planes = planeRepository;
        }

        /// <summary>
        /// Planes
        /// </summary>
        public IPlaneRepository Planes { get; }
    }
}
