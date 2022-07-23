using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFortress.API.DAL;
using TheFortress.API.Data;
using TheFortress.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheFortress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventConcertController : ControllerBase
    {
        private UnitOfWork unitOfWork;

        public EventConcertController(TheFortressContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }


        [Authorize]
        [RequiredScope("tasks.read")]
        [HttpGet]
        public async Task<IEnumerable<EventConcert>> Get()
        {
            return await unitOfWork.EventConcertRepository.Get(includeProperties: "VenueFkNavigation");
        }

        // GET /<ConcertController>/5
        [Authorize]
        [RequiredScope("tasks.read")]
        [HttpGet("{id}")]
        public EventConcert GetById(int id)
        {
            //return await unitOfWork.EventConcertRepository.GetByID(id);
            return unitOfWork.EventConcertRepository
                .Get(e => e.EventConcertId == id,
                    includeProperties: "VenueFkNavigation").Result.FirstOrDefault() ?? new EventConcert();
        }

        [HttpGet("city/{city}")]
        public async Task<IEnumerable<EventConcert>> GetByCity(string city)
        {
            return await unitOfWork.EventConcertRepository
                .Get(e => e.VenueFkNavigation.CityFkNavigation.CityName == city && e.EventDate >= DateTime.Today.AddDays(-1),
                    orderBy: e => e.OrderBy(x => x.EventDate),
                    includeProperties: "VenueFkNavigation");
        }

        [HttpGet("{venueId}/{isVenue}")]
        public Task<IEnumerable<EventConcert>> GetByVenue(int venueId, bool isVenue)
        {
            return unitOfWork.EventConcertRepository
                .Get(e => e.VenueFk == venueId && e.EventDate >= DateTime.Today.AddDays(-1),
                    orderBy: e => e.OrderBy(x => x.EventDate),
                    includeProperties: "VenueFkNavigation");
        }

        [Authorize]
        [HttpPost]
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

        [Authorize]
        [HttpPut("{id}")]
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

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.EventConcertRepository.Delete(id);
        }
    }
}
