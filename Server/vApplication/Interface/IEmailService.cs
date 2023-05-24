using RestSharp;
using vDomain.Dto;
using vDomain.Enum;

namespace vApplication.Interface;

public interface IEmailService
{
    Task<RestResponse> SendMailAsync(EmailVariablesDto variables, string templateName, object? templateVars);
    Task<RestResponse> SendEmailTypeAsync(EmailTypeEnum type, string destinationEmail, string recieverName, string url = "");
}