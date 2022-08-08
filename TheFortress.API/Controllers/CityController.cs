using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TheFortress.API.Models;
using TheFortress.API.DAL;
using TheFortress.API.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheFortress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        UnitOfWork unitOfWork;

        public CityController(TheFortressContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }


        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await unitOfWork.CityRepository.Get();
        }

        // GET <CityController>/5
        [HttpGet("{id}")]
        public async Task<City> GetById(int id)
        {
            return await unitOfWork.CityRepository.GetByID(id);
        }

        [Authorize]
        [HttpPost]
        public City Post([FromBody] City value)
        {
            City item = new City();
            item.CityName = value.CityName;
            item.Image = value.Image;

            unitOfWork.CityRepository.Insert(item);
            unitOfWork.Save();
            return item;
        }

        [Authorize]
        [HttpPut("{id}")]
        public City Put(int id, [FromBody] City value)
        {
            City item = new City();
            item.CityId = id;
            item.CityName = value.CityName;
            item.Image = value.Image;

            unitOfWork.CityRepository.Update(item);
            unitOfWork.Save();
            return item;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.CityRepository.Delete(id);
        }
    }
}
