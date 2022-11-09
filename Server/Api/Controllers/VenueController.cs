using Api.Attributes;
using Api.Data;
using Api.Forms;
using Api.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        UnitOfWork unitOfWork;
        IStorageService _storageService;

        public VenueController(TheFortressContext context, IStorageService storageService)
        {
            unitOfWork = new UnitOfWork(context);
            _storageService = storageService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ReturnType("Venue[]")]
        public async Task<ActionResult<IEnumerable<Venue>>> Get()
        {
            try
            {
                var items =  await unitOfWork.VenueRepository.Get(includeProperties: "CityFkNavigation");

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

        [NTypewriterIgnore]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostWithImage()
        {

            var formRequest = Request.Form;
            IFormFile file = formRequest.Files.First(); 
            VenueFormModel? venue= JsonConvert.DeserializeObject<VenueFormModel>(formRequest.First().Value);
            string imageUrl = await _storageService.StoreImageFile(file);

            Venue item = new Venue();
            item.Hours = venue.Hours;
            item.TicketsLink = venue.TicketsLink;
            item.MenuLink = venue.MenuLink;
            item.Address = venue.Address;
            item.CityFk = item.CityFk;
            item.Description = item.Description;
            item.VenueName = venue.VenueName;
            item.Picture = imageUrl;

            //unitOfWork.EventConcertRepository.Insert(item);
            //unitOfWork.Save();
            return new ObjectResult(item);
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
