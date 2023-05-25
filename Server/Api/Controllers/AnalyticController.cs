using vApplication.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vInfra.Context;
using vInfra;

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
        try
        {
            Analytic a = new Analytic();

            a.IpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            a.DateAdded = DateTime.Now;

            unitOfWork.AnalyticRepository.Insert(a);
            unitOfWork.Save();

        }
        catch(Exception ex)
        {
            //return StatusCode(500); 
        }
    }
}
