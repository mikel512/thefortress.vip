using System;
using Microsoft.Extensions.Configuration;
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

        public async Task<RestResponse> SendMailAsync(string from, string sender, string to, string subject, string body)
        {
            String apiKey = _configuration.GetValue<string>("MailgunKey");

            RestClient client = new RestClient(_apiEndpoint); 
            client.Authenticator = new HttpBasicAuthenticator("api", apiKey);

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mg.thefortress.vip", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", $"{sender} <{from}>");
            request.AddParameter("to", to);
            request.AddParameter("subject", subject);
            request.AddParameter("html", body);
            request.Method = Method.Post;

            return await client.ExecuteAsync(request);
        }
    }
}