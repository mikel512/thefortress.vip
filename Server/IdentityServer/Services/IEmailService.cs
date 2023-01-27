using RestSharp;

namespace IdentityServer.Services
{
    public interface IEmailService
    {
        Task<RestResponse> SendMailAsync(EmailVariables variables, string templateName, object? templateVars);
        Task<RestResponse> SendEmailTypeAsync(EmailType type, string destinationEmail, string recieverName, string url = "");
    }
}