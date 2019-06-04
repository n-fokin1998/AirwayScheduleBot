// <copyright file="EmailService.cs" company="Kharkiv National Aerospace University">
// Copyright (c) Kharkiv National Aerospace University. All rights reserved.
// </copyright>

namespace AirwaySchedule.Bot.BotProcessing.Infrastructure
{
    using System.Text;

    using System.Net.Mail;

    using AirwaySchedule.Bot.Common.Models;
    using AirwaySchedule.Bot.BotProcessing.Interfaces.Infrastructure;
    using AirwaySchedule.Bot.IntegrationProxy.Contracts.YandexApi;

    /// <summary>
    /// EmailService
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly EmailSenderConfiguration _emailConfiguration;
        private readonly IMessageSender _messageSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="emailConfiguration">emailConfiguration</param>
        /// <param name="messageSender">messageSender</param>
        public EmailService(EmailSenderConfiguration emailConfiguration, IMessageSender messageSender)
        {
            _emailConfiguration = emailConfiguration;
            _messageSender = messageSender;
        }

        /// <summary>
        /// SendScheduleLetter
        /// </summary>
        /// <param name="responseModel">responseModel</param>
        /// <param name="email">email</param>
        public void SendScheduleLetter(YandexApiResponse responseModel, string email)
        {
            const string letterSubject = "Airway schedule";

            using (var emailMessage = new MailMessage())
            {
                emailMessage.To.Add(new MailAddress(email));
                emailMessage.From = new MailAddress(_emailConfiguration.Email);
                emailMessage.Subject = letterSubject;
                emailMessage.Body = BuildLetterBody(responseModel);

                _messageSender.Send(emailMessage);
            }
        }

        private string BuildLetterBody(YandexApiResponse responseModel)
        {
            var result = new StringBuilder();

            foreach (var segment in responseModel.Segments)
            {
                result.AppendLine();

                result.Append(
                    $"Flight: {segment.Thread.Title}\n" +
                    $"Flight number: {segment.Thread.Number}\n" +
                    $"Departure: {segment.DeparturePoint.Title}\n" +
                    $"Arrival: {segment.ArrivalPoint.Title}\n" +
                    $"Departure date: {segment.Departure.ToShortDateString() + " " + segment.Departure.ToShortTimeString()}\n" +
                    $"Arrival date: {segment.Arrival.ToShortDateString() + " " + segment.Arrival.ToShortTimeString()}\n" +
                    $"Airline: {segment.Thread.Carrier.Title}\n" +
                    $"Site: {segment.Thread.Carrier.Url}\n" +
                    $"Plane: {segment.Thread.Vehicle}");

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
