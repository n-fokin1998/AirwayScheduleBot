// <copyright file="DependencyRegistry.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI.Infrastructure.DI
{
    using Microsoft.Extensions.Configuration;

    using Autofac;

    using AirwaySchedule.Bot.DataAccess.Mongo;
    using BotProcessing.Interfaces.Services;
    using BotProcessing.Interfaces.Services.Commands;
    using AirwaySchedule.Bot.BotProcessing.Services;
    using AirwaySchedule.Bot.BotProcessing.Services.Commands;
    using AirwaySchedule.Bot.DataAccess.Interfaces;
    using AirwaySchedule.Bot.DataAccess.Repositories;
    using AirwaySchedule.Bot.IntegrationProxy.Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Services;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Interfaces.Services;
    using AirwaySchedule.Bot.IntegrationProxy.Models;
    using AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator;
    using AirwaySchedule.Bot.BotProcessing.Infrastructure.ScheduleRequestCreator.Strategies;
    using BotProcessing.Interfaces.Infrastructure.ScheduleRequestCreator;
    using AirwaySchedule.Bot.Common.Utils;
    using AirwaySchedule.Bot.BotProcessing.Infrastructure;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.Common.Models;

    /// <summary>
    /// DependencyRegistry
    /// </summary>
    public static class DependencyRegistry
    {
        /// <summary>
        /// Add builder.
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="connectionString">connectionString</param>
        public static void AddServices(this ContainerBuilder builder, string connectionString)
        {
            builder.RegisterType<CommandInvokerService>().As<ICommandInvokerService>();
            builder.RegisterType<ScheduleCommandService>().As<IScheduleCommandService>();
            builder.RegisterType<PlaneDetailsCommandService>().As<IPlaneDetailsCommandService>();
            builder.RegisterType<HelpCommandService>().As<IHelpCommandService>();
            builder.RegisterType<SetEmailCommandService>().As<ISetEmailCommandService>();
            builder.RegisterType<SendByEmailCommandService>().As<ISendByEmailCommandService>();

            builder.RegisterType<ScheduleRequestCreator>().As<IScheduleRequestCreator>();
            builder.RegisterType<RequestByIataStrategy>().Keyed<IScheduleRequestStrategy>(CommandNames.ScheduleByIataCommand);
            builder.RegisterType<RequestByCityStrategy>().Keyed<IScheduleRequestStrategy>(CommandNames.ScheduleByCityCommand);
            builder.RegisterType<RequestByAirportStrategy>().Keyed<IScheduleRequestStrategy>(CommandNames.ScheduleByAirportCommand);

            builder.RegisterType<YandexApiProxy>().As<IYandexApiProxy>();
            builder.RegisterType<IataApiProxy>().As<IIataApiProxy>();
            builder.RegisterType<RestSharpHelper>().As<IRestSharpHelper>();
            builder.RegisterType<MessageSender>().As<IMessageSender>();
            builder.RegisterType<EmailService>().As<IEmailService>();

            builder.RegisterType<PlaneRepository>().As<IPlaneRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.Register(x => new AirwayScheduleContext(connectionString)).InstancePerLifetimeScope();
        }

        /// <summary>
        /// Add configuration models.
        /// </summary>
        /// <param name="builder">builder</param>
        /// <param name="configuration">configuration</param>
        public static void AddConfiguration(this ContainerBuilder builder, IConfiguration configuration)
        {
            var yandexApiConfig = configuration.GetSection(nameof(YandexApiConfiguration)).Get<YandexApiConfiguration>();
            var iataApiConfig = configuration.GetSection(nameof(IataApiConfiguration)).Get<IataApiConfiguration>();
            var emailSenderConfig = configuration.GetSection(nameof(EmailSenderConfiguration)).Get<EmailSenderConfiguration>();

            builder.Register(x => yandexApiConfig).SingleInstance();
            builder.Register(x => iataApiConfig).SingleInstance();
            builder.Register(x => emailSenderConfig).SingleInstance();
        }
    }
}
