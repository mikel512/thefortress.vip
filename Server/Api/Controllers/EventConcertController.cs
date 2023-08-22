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
    private readonly IEventConcertService _eventConcertService;

    public EventConcertController(IEventConcertService eventConcertService)
    {
        _eventConcertService = eventConcertService;
    }


    [HttpGet]
    [AllowAnonymous]
    [ReturnType("EventConcert[]")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return new ObjectResult(await _eventConcertService.ListPublic());
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
            return new ObjectResult(_eventConcertService.GetById(id)); 
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
            return new ObjectResult(await _eventConcertService.ListByCityPublic(name));
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
            return new ObjectResult(await _eventConcertService.ListByVenuePublic(id));

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
            return new ObjectResult(_eventConcertService.Save(concert));
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
            var result = await _eventConcertService.SaveWithFlyer(formRequest.FirstOrDefault().Value, formRequest.Files.FirstOrDefault());
            return new ObjectResult(result);

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
            //EventConcert item = new EventConcert();
            //item.EventConcertId = id;
            //item.EventName = concert.EventName;
            //item.EventDate = concert.EventDate;
            //item.EventTime = concert.EventTime;
            //item.Details = concert.Details;
            //item.Tickets = concert.Tickets;
            //item.Flyer = concert.Flyer;
            //item.Status = concert.Status;

            //unitOfWork.EventConcertRepository.Update(item);
            //unitOfWork.Save();
            return Ok();
            //return new ObjectResult(item);

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
            //unitOfWork.EventConcertRepository.Delete(id);
            //unitOfWork.Save();

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
