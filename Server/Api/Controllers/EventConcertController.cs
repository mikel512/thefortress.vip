using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vApplication.Context;
using vDomain.Interface;
using vDomain.Attributes;
using vDomain.Entity;
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
    public async Task<List<EventConcert>> Get()
    {
        return await _eventConcertService.ListPublic();
    }

    // GET /<ConcertController>/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    [ReturnType("EventConcert")]
    public EventConcert GetById(int id)
    {
        return _eventConcertService.GetById(id);
    }

    [HttpGet("[action]/{name}")]
    [AllowAnonymous]
    [ReturnType("EventConcert[]")]
    public async Task<List<EventConcert>> GetByCity(string name)
    {
        return await _eventConcertService.ListByCityPublic(name);
    }

    [HttpGet("[action]/{id}")]
    [AllowAnonymous]
    [ReturnType("EventConcert[]")]
    public async Task<List<EventConcert>> GetByVenue(int id)
    {
        return await _eventConcertService.ListByVenuePublic(id);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ReturnType("EventConcert")]
    public EventConcert Post([FromBody] EventConcert concert)
    {
        return _eventConcertService.Save(concert);
    }


    [NTypewriterIgnore]
    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<EventConcert> PostWithFlyerFile()
    {
        var formRequest = Request.Form;
        return await _eventConcertService.SaveWithFlyer(formRequest.FirstOrDefault().Value, formRequest.Files.FirstOrDefault()); 
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
