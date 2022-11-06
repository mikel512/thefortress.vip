using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Api.Data;
using Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
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


        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
        {
            try
            {
                var items = await unitOfWork.CityRepository.Get();

                return new ObjectResult(items);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET <CityController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetById(int id)
        {
            try
            {
                var item = await unitOfWork.CityRepository.GetByID(id);

                return new ObjectResult(item);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public City Post([FromBody] City value)
        {
            City item = new City();
            item.CityName = value.CityName;
            item.Image = value.Image;

            unitOfWork.CityRepository.Insert(item);
            unitOfWork.Save();
            return item;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            unitOfWork.CityRepository.Delete(id);
        }
    }
}
