// <copyright file="Plane.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.Common.Models
{
    /// <summary>
    /// Plane
    /// </summary>
    public class Plane
    {
        /// <summary>
        /// PlaneId
        /// </summary>
        public int PlaneId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Seats
        /// </summary>
        public string Seats { get; set; }

        /// <summary>
        /// Range
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// Speed
        /// </summary>
        public string Speed { get; set; }
    }
}
