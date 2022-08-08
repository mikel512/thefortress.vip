using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class VenueController : ControllerBase
    {
        UnitOfWork unitOfWork;

        public VenueController(TheFortressContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Venue>> Get()
        {
            return await unitOfWork.VenueRepository.Get();

        }

        [HttpGet("city/{city}")]
        public async Task<IEnumerable<Venue>> GetByCity(string city)
        {
            var res = await unitOfWork.VenueRepository.Get(v => v.CityFkNavigation.CityName == city);
            return res;

        }

        [HttpGet("{id}")]
        public async Task<Venue> GetById(int id)
        {
            return await unitOfWork.VenueRepository.GetByID(id);
        }

        [Authorize]
        [HttpPost]
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

        // PUT api/<VenueController>/5
        [Authorize]
        [HttpPut("{id}")]
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

        // DELETE api/<VenueController>/5 
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //unitOfWork.VenueRepository.Delete(id);
            //unitOfWork.Save();
          

        }
    }
}
