// <copyright file="AdminPanelMappingProfile.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.AdminPanelProcessing.Infrastructure
{
    using Common.Models;
    using AirwaySchedule.Bot.DataAccess.Entities;
    using AutoMapper;

    /// <summary>
    /// AdminPanelMappingProfile
    /// </summary>
    public class AdminPanelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminPanelMappingProfile"/> class.
        /// </summary>
        public AdminPanelMappingProfile()
        {
            CreateMap<DataAccess.Entities.Plane, Common.Models.Plane>().ReverseMap();
        }
    }
}
