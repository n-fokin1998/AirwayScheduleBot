// <copyright file="Startup.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI
{
    using System;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Autofac;
    using Swashbuckle.AspNetCore.Swagger;
    using Telegram.Bot;

    using Autofac.Extensions.DependencyInjection;
    using AirwaySchedule.Bot.WebAPI.Filters;
    using AirwaySchedule.Bot.WebAPI.Infrastructure.DI;

    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="environment">environment</param>
        public Startup(ILogger<Startup> logger, IHostingEnvironment environment)
        {
            _logger = logger;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Container
        /// </summary>
        public IContainer Container { get; private set; }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">services</param>
        /// <returns>IServiceProvider</returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            var botClient = SetupBotClient();

            var connectionString = Configuration.GetConnectionString("AirwayScheduleDatabase");

            builder.Register(x => botClient).As<ITelegramBotClient>().SingleInstance();
            builder.AddConfiguration(Configuration);
            builder.AddServices(connectionString);

            services.AddMemoryCache();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ServiceExceptionFilterAttribute));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            builder.Populate(services);
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }

        private TelegramBotClient SetupBotClient()
        {
            var botClient = new TelegramBotClient(Configuration["TelegramBotConfiguration:Token"]);

            // ngrok http localhost:50208 -host-header=localhost
            botClient.SetWebhookAsync("https://769f2730.ngrok.io/api/bot/update").Wait();
            _logger.LogInformation("Created bot client with Id: " + botClient.BotId);

            return botClient;
        }
    }
}
