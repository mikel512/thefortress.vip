using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFortress.API.DAL;
using TheFortress.API.Data;
using TheFortress.API.Models;

namespace TheFortress.API.Controllers
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
                await unitOfWork.Save();

            }
            catch(Exception ex)
            {
                //return StatusCode(500); 
            }
        }
    }
}
