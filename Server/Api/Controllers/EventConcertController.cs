using Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vApplication.Context;
using vDomain.Interface;
using vDomain.Attributes;
using vDomain.Entity;
using vDomain.Forms;
using vApplication.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers;

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
    public async Task<IActionResult> Get()
    {
        try
        {
            var items = await unitOfWork.EventConcertRepository
            .Get(e => e.EventDate.Date >= DateTime.Today.Date,
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
    public IActionResult GetById(int id)
    {
        try
        {
            var item = unitOfWork.EventConcertRepository
                .Get(e => e.EventConcertId == id,
                    includeProperties: "VenueFkNavigation").Result.FirstOrDefault() ?? new EventConcert();

            return new ObjectResult(item);

        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("[action]/{name}")]
    [AllowAnonymous]
    [ReturnType("EventConcert[]")]
    public async Task<IActionResult> GetByCity(string name)
    {
        try
        {
            var items = await unitOfWork.EventConcertRepository
                .Get(e => e.VenueFkNavigation!.CityFkNavigation.CityName == name && e.EventDate >= DateTime.Today.AddDays(-1),
                    orderBy: e => e.OrderBy(x => x.EventDate),
                    includeProperties: "VenueFkNavigation");

            return new ObjectResult(items);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("[action]/{id}")]
    [AllowAnonymous]
    [ReturnType("EventConcert[]")]
    public async Task<IActionResult> GetByVenue(int id)
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
    public IActionResult Post([FromBody] EventConcert concert)
    {
        try
        {
            EventConcert item = new EventConcert();
            item.EventName = concert.EventName;
            item.EventDate = concert.EventDate;
            item.EventTime = concert.EventTime;
            item.Details = concert.Details;
            item.Tickets = concert.Tickets;
            item.Flyer = concert.Flyer;
            item.Status = concert.Status;
            item.VenueFk = concert.VenueFk;

            unitOfWork.EventConcertRepository.Insert(item);
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
    public async Task<IActionResult> PostWithFlyerFile()
    {
        try
        {
            var formRequest = Request.Form;
            IFormFile file = formRequest.Files.First();
            // validate file extension
            if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
            {
                return StatusCode(StatusCodes.Status415UnsupportedMediaType);
            }

            EventConcertFormModel? concert = JsonConvert.DeserializeObject<EventConcertFormModel>(formRequest.First().Value);
            string flyerUrl = await _storageService.StoreImageFile(file);

            EventConcert item = new EventConcert();
            item.EventName = concert.EventName;
            item.EventDate = concert.EventDate;
            item.EventTime = concert.EventTime;
            item.Details = concert.Details;
            item.Tickets = concert.TicketsUrl;
            item.Flyer = flyerUrl;
            item.VenueFk = concert.VenueFk;

            unitOfWork.EventConcertRepository.Insert(item);
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
    [ReturnType("EventConcert")]
    public IActionResult Put(int id, [FromBody] EventConcert concert)
    {
        try
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
    public IActionResult Delete(int id)
    {
        try
        {
            unitOfWork.EventConcertRepository.Delete(id);
            unitOfWork.Save();

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
