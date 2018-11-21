// <copyright file="Startup.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.WebAPI
{
    using AirwaySchedule.Bot.WebAPI.Filters;
    using AirwaySchedule.Bot.WebAPI.Infrastructure.DI;
    using IntegrationProxy.Models.Response;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Telegram.Bot;

    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">configuration</param>
        /// <param name="logger">logger</param>
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.GetSection(nameof(YandexApiConfiguration)).Get<YandexApiConfiguration>();
            services.AddSingleton(config);

            var botClient = new TelegramBotClient(Configuration["TelegramBotConfiguration:Token"]);
            botClient.SetWebhookAsync("url").Wait();
            _logger.LogInformation("Created bot client with Id: " + botClient.BotId);

            services.AddSingleton<ITelegramBotClient>(botClient);
            services.AddServices();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ServiceExceptionFilterAttribute));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
