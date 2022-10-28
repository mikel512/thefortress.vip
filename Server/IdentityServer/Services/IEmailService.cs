using RestSharp;

namespace IdentityServer.Services
{
    public interface IEmailService
    {
        Task<RestResponse> SendMailAsync(string from, string sender, string to, string subject, string body);
    }
}