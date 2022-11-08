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
    public class EventConcertController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private IConfiguration _configuration;
        private IStorageService _storageService;

        public EventConcertController(TheFortressContext context, IConfiguration configuration, IStorageService storageService)
        {
            unitOfWork = new UnitOfWork(context);
            _configuration = configuration;
            _storageService = storageService;
        }


        [HttpGet]
        [AllowAnonymous]
        [ReturnType("EventConcert[]")]
        public async Task<ActionResult<IEnumerable<EventConcert>>> Get()
        {
            try
            {
                var items = await unitOfWork.EventConcertRepository
                .Get(e => e.EventDate >= DateTime.Today.AddDays(-1),
                orderBy: e => e.OrderBy(x => x.EventDate),
                includeProperties: "VenueFkNavigation");

                return new ObjectResult(items);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET /<ConcertController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ReturnType("EventConcert")]
        public ActionResult<EventConcert> GetById(int id)
        {
            try
            {
                return unitOfWork.EventConcertRepository
                    .Get(e => e.EventConcertId == id,
                        includeProperties: "VenueFkNavigation").Result.FirstOrDefault() ?? new EventConcert();

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("[action]/{name}")]
        [AllowAnonymous]
        [ReturnType("EventConcert[]")]
        public async Task<ActionResult<IEnumerable<EventConcert>>> GetByCity(string name)
        {
            try
            {
                var items = await unitOfWork.EventConcertRepository
                    .Get(e => e.VenueFkNavigation!.CityFkNavigation.CityName == name && e.EventDate >= DateTime.Today.AddDays(-1),
                        orderBy: e => e.OrderBy(x => x.EventDate),
                        includeProperties: "VenueFkNavigation");

                return new ObjectResult(items);
            }
            catch (Exception )
            {
                return StatusCode(500);
            }
        }

        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        [ReturnType("EventConcert[]")]
        public async Task<ActionResult<IEnumerable<EventConcert>>> GetByVenue(int id)
        {
            try
            {
                var items = await unitOfWork.EventConcertRepository
                    .Get(e => e.VenueFk == id && e.EventDate >= DateTime.Today.AddDays(-1),
                        orderBy: e => e.OrderBy(x => x.EventDate),
                        includeProperties: "VenueFkNavigation");

                return new ObjectResult(items);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ReturnType("EventConcert")]
        public EventConcert Post([FromBody] EventConcert concert)
        {
            EventConcert item = new EventConcert();
            item.EventName = concert.EventName;
            item.EventDate = concert.EventDate;
            item.EventTime = concert.EventTime;
            item.Details = concert.Details;
            item.Tickets = concert.Tickets;
            item.Flyer = concert.Flyer;
            item.Status = concert.Status;

            unitOfWork.EventConcertRepository.Insert(item);
            unitOfWork.Save();
            return item;
        }


        [NTypewriterIgnore]
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostWithFlyerFile()
        {

            var h = Request.Form;
            IFormFile file = h.Files.First(); 
            EventConcertFormModel? concert = JsonConvert.DeserializeObject<EventConcertFormModel>(h.First().Value);
            string flyerUrl = await _storageService.StoreImageFile(file);

            EventConcert item = new EventConcert();
            item.EventName = concert.EventName;
            item.EventDate = concert.EventDate;
            item.EventTime = concert.EventTime;
            item.Details = concert.Details;
            item.Tickets = concert.TicketsUrl;
            item.Flyer = flyerUrl;

            //unitOfWork.EventConcertRepository.Insert(item);
            //unitOfWork.Save();
            return new ObjectResult(item);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ReturnType("EventConcert")]
        public EventConcert Put(int id, [FromBody] EventConcert concert)
        {
            EventConcert item = new EventConcert();
            item.EventConcertId = id;
            item.EventName = concert.EventName;
            item.EventDate = concert.EventDate;
            item.EventTime = concert.EventTime;
            item.Details = concert.Details;
            item.Tickets = concert.Tickets;
            item.Flyer = concert.Flyer;
            item.Status = concert.Status;

            unitOfWork.EventConcertRepository.Update(item);
            unitOfWork.Save();
            return item;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ReturnType("any")]
        public void Delete(int id)
        {
            unitOfWork.EventConcertRepository.Delete(id);
            unitOfWork.Save();
        }
    }
}
