using System;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace IdentityServer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly String _apiEndpoint = "https://api.mailgun.net/v3";
        private static string _defaultSender = "The Fortress";
        private static string _defaultFrom = "thefortress-verification@thefortress.vip";

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RestResponse> SendMailAsync(EmailVariables variables, string templateName, object templateVars)
        {
            String apiKey = _configuration.GetValue<string>("MailgunKey");

            RestClient client = new RestClient(_apiEndpoint);
            client.Authenticator = new HttpBasicAuthenticator("api", apiKey);

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.thefortress.vip", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", $"{variables.Sender} <{variables.From}>");
            request.AddParameter("to", variables.To);
            request.AddParameter("subject", variables.Subject);
            request.AddParameter("template", templateName);
            request.AddParameter("h:X-Mailgun-Variables", JsonConvert.SerializeObject(templateVars));
            request.Method = Method.Post;

            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> SendEmailTypeAsync(EmailType type, string destinationEmail, string recieverName, string url = "")
        {
            EmailVariables emailVars = new EmailVariables()
            {
                Sender = $"{_defaultSender}",
                From = _defaultFrom,
                To = destinationEmail,
            };

            if (type == EmailType.VerificationEmail)
            {
                emailVars.Subject = EmailSubject.ConfirmEmail;

                object templateVars =
                    new
                    {
                        name = recieverName,
                        text_body = $"Please Verify that your email address is {destinationEmail} and that you entered it when signing up for The Fortress.",
                        link_url = HtmlEncoder.Default.Encode(url),
                        link_text = "Verify Email"
                    };

                return await SendMailAsync(emailVars, EmailTemplate.EmailWithLink, templateVars);
            }

            return new RestResponse();
        }
    }

    public enum EmailType
    {
        VerificationEmail,
    }

    public static class EmailTemplate
    {
        public static readonly string EmailWithLink = "basic_link";
        public static readonly string InfoEmail = "info_email";
    }

    public static class EmailSubject
    {
        public static readonly string ConfirmEmail = "Confirm your email";
    }

    public class EmailVariables
    {
        public string From { get; set; }
        public string Sender { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}