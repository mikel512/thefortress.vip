using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vApplication.Context;
using vDomain.Attributes;
using vDomain.Entity;

namespace Api.Controllers;

[NTypewriterIgnore]
[Route("api/[controller]")]
[ApiController]
public class AnalyticController : ControllerBase
{
    private UnitOfWork unitOfWork;

    public AnalyticController(TheFortressContext context)
    {
        unitOfWork = new UnitOfWork(context);
    }
    [HttpGet]
    public async void Get()
    {
        Analytic a = new Analytic();

        a.IpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
        a.DateAdded = DateTime.Now;

        unitOfWork.AnalyticRepository.Insert(a);
        unitOfWork.Save();
    }
}
