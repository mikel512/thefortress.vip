using System;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using vApplication.Interface;
using vDomain.Constants;
using vDomain.Dto;
using vDomain.Enum;

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

        public async Task<RestResponse> SendMailAsync(EmailVariablesDto variables, string templateName, object templateVars)
        {
            // fix this
            //String apiKey = _configuration.GetValue<string>("MailgunKey");

            RestClient client = new RestClient(_apiEndpoint);
            //client.Authenticator = new HttpBasicAuthenticator("api", apiKey);

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

        public async Task<RestResponse> SendEmailTypeAsync(EmailTypeEnum type, string destinationEmail, string recieverName, string url = "")
        {
            EmailVariablesDto emailVars = new EmailVariablesDto()
            {
                Sender = $"{_defaultSender}",
                From = _defaultFrom,
                To = destinationEmail,
            };

            if (type == EmailTypeEnum.VerificationEmail)
            {
                emailVars.Subject = EmailSubjectConstants.ConfirmEmail;

                object templateVars =
                    new
                    {
                        name = recieverName,
                        text_body = $"Please Verify that your email address is {destinationEmail} and that you entered it when signing up for The Fortress.",
                        link_url = HtmlEncoder.Default.Encode(url),
                        link_text = "Verify Email"
                    };

                return await SendMailAsync(emailVars, EmailTemplateConstants.EmailWithLink, templateVars);
            }

            return new RestResponse();
        }
    } 
}