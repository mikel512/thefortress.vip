using Api.DAL;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
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


        [HttpGet]
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.EventConcertRepository.Delete(id);
        }
    }
}
