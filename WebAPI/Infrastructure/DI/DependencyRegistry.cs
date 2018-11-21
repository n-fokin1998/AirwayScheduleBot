// <copyright file="DependencyRegistry.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Infrastructure.DI
{
    using AirwaySchedule.Bot.BotProcessing.Interfaces;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Commands;
    using AirwaySchedule.Bot.BotProcessing.Services;
    using AirwaySchedule.Bot.BotProcessing.Services.Commands;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces;
    using AirwaySchedule.Bot.IntegrationProxy.Services;
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
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IYandexApiProxy, YandexApiProxy>();
            services.AddScoped<ICommandInvokerService, CommandInvokerService>();
            services.AddScoped<IScheduleCommandService, ScheduleCommandService>();
        }
    }
}
