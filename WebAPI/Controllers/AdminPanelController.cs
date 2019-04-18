﻿// <copyright file="AdminPanelController.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Controllers
{
    using AirwaySchedule.Bot.AdminPanelProcessing.Interfaces;
    using AirwaySchedule.Bot.Common.FilterModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// AdminPanelController
    /// </summary>
    [Route("api/admin")]
    public class AdminPanelController : Controller
    {
        private readonly IPlaneService _planeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminPanelController"/> class.
        /// </summary>
        /// <param name="planeService">planeService</param>
        public AdminPanelController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="searchKey">searchKey</param>
        /// <param name="page">page</param>
        /// <returns>IActionResult</returns>
        [HttpGet("planes")]
        public IActionResult Get(string searchKey, int page = 1)
        {
            var pagingInfo = new PagingInfo
            {
                PageNumber = page
            };
            var filteredPlanes = _planeService.GetFilteredPlanes(searchKey, pagingInfo);

            return Json(new
            {
                Items = filteredPlanes,
                pagingInfo.TotalCount
            });
        }
    }
}
