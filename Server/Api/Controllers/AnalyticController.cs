using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
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
}
