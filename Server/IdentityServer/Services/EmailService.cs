using System;
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
    }

    public static class EmailTemplate
    {
        public static readonly string BasicLink = "basic_link";
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