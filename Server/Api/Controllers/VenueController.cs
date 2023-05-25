using Api.Data;
using Api.Extensions;
using Api.Forms;
using Api.Models;
using vApplication.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vApplication.Interface;

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
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await unitOfWork.VenueRepository.Get(includeProperties: "CityFkNavigation");

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
        public async Task<IActionResult> GetByCity(string city)
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
        public IActionResult Post([FromBody] Venue value)
        {
            try
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
                return new ObjectResult(item);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [NTypewriterIgnore]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostWithImage()
        {

            try
            {
                var formRequest = Request.Form;
                IFormFile file = formRequest.Files.First();

                if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
                {
                    return StatusCode(StatusCodes.Status415UnsupportedMediaType);
                }

                VenueFormModel? venue = JsonConvert.DeserializeObject<VenueFormModel>(formRequest.First().Value);
                string imageUrl = await _storageService.StoreImageFile(file);

                Venue item = new Venue();
                item.Hours = venue.Hours;
                item.TicketsLink = venue.TicketsLink;
                item.MenuLink = venue.MenuLink;
                item.Address = venue.Address;
                item.CityFk = venue.CityFk;
                item.Description = venue.Description;
                item.VenueName = venue.VenueName;
                item.Location = venue.Location;
                item.Picture = imageUrl;

                unitOfWork.VenueRepository.Insert(item);
                unitOfWork.Save();
                return new ObjectResult(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ReturnType("Venue")]
        public IActionResult Put(int id, [FromBody] Venue value)
        {
            try
            {
                Venue item = new Venue();
                item.VenueId = id;
                item.Picture = value.Picture;
                item.Hours = value.Hours;
                item.TicketsLink = value.TicketsLink;
                item.MenuLink = value.MenuLink;
                item.Address = value.Address;
                item.CityFk = value.CityFk;
                item.Description = value.Description;
                item.VenueName = value.VenueName;
                item.Location = value.Location;

                unitOfWork.VenueRepository.Update(item);
                unitOfWork.Save();
                return new ObjectResult(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
