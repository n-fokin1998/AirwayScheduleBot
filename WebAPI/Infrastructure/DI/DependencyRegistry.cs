// <copyright file="DependencyRegistry.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Infrastructure.DI
{
    using AirwaySchedule.Bot.AdminPanelProcessing.Infrastructure;
    using AirwaySchedule.Bot.AdminPanelProcessing.Interfaces;
    using AirwaySchedule.Bot.AdminPanelProcessing.Services;
    using AirwaySchedule.Bot.BotProcessing.Interfaces;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Commands;
    using AirwaySchedule.Bot.BotProcessing.Services;
    using AirwaySchedule.Bot.BotProcessing.Services.Commands;
    using AirwaySchedule.Bot.DataAccess;
    using AirwaySchedule.Bot.DataAccess.Filter;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using AirwaySchedule.Bot.DataAccess.Interfaces.Filter;
    using AirwaySchedule.Bot.DataAccess.Repositories;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces;
    using AirwaySchedule.Bot.IntegrationProxy.Services;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// DependencyRegistry
    /// </summary>
    public static class DependencyRegistry
    {
        /// <summary>
        /// AddServices
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="connectionString">connectionString</param>
        public static void AddServices(this IServiceCollection services, string connectionString)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AdminPanelMappingProfile>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IYandexApiProxy, YandexApiProxy>();
            services.AddScoped<ICommandInvokerService, CommandInvokerService>();
            services.AddScoped<IScheduleCommandService, ScheduleCommandService>();
            services.AddScoped<IPlaneService, PlaneService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlaneRepository, PlaneRepository>();
            services.AddScoped<IFilterPipelineBuilder, FilterPipelineBuilder>();
            services.AddScoped(x => new AirwayScheduleContext(connectionString));
        }
    }
}
