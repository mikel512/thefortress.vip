using Api.Attributes;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        UnitOfWork unitOfWork;

        public VenueController(TheFortressContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [AllowAnonymous]
        [HttpGet]
        [ReturnType("Venue[]")]
        public async Task<ActionResult<IEnumerable<Venue>>> Get()
        {
            try
            {
                var items =  await unitOfWork.VenueRepository.Get();

                return new ObjectResult(items);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [AllowAnonymous]
        [HttpGet("city/{city}")]
        [ReturnType("Venue[]")]
        public async Task<ActionResult<IEnumerable<Venue>>> GetByCity(string city)
        {
            try
            {
                var items = await unitOfWork.VenueRepository.Get(v => v.CityFkNavigation.CityName == city);

                return new ObjectResult(items);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ReturnType("Venue")]
        public async Task<ActionResult<Venue>> GetById(int id)
        {
            try
            {
                var items = await unitOfWork.VenueRepository.GetByID(id);

                return new ObjectResult(items);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ReturnType("Venue")]
        public Venue Post([FromBody] Venue value)
        {
            Venue item = new Venue();
            item.Picture = value.Picture;
            item.Hours = value.Hours;
            item.TicketsLink = value.TicketsLink;
            item.MenuLink = value.MenuLink;
            item.Address = value.Address;
            item.CityFk = item.CityFk;
            item.Description = item.Description;
            item.VenueName = value.VenueName;

            unitOfWork.VenueRepository.Insert(item);
            unitOfWork.Save();
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ReturnType("Venue")]
        public Venue Put(int id, [FromBody] Venue value)
        {
            Venue item = new Venue();
            item.VenueId = id;
            item.Picture = value.Picture;
            item.Hours = value.Hours;
            item.TicketsLink = value.TicketsLink;
            item.MenuLink = value.MenuLink;
            item.Address = value.Address;
            item.CityFk = item.CityFk;
            item.Description = item.Description;
            item.VenueName = value.VenueName;

            unitOfWork.VenueRepository.Update(item);
            unitOfWork.Save();
            return item;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ReturnType("any")]
        public void Delete(int id)
        {
            //unitOfWork.VenueRepository.Delete(id);
            //unitOfWork.Save(); 
        }
    }
}
