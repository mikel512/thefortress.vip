using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using vApplication.Attributes;
using vInfra.Context;
using vInfra;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers;

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
    [ReturnType("City[]")]
    public async Task<IActionResult> Get()
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
    [ReturnType("City")]
    public async Task<IActionResult> GetById(int id)
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
    [ReturnType("City")]
    public IActionResult Post([FromBody] City value)
    {
        try
        {
            City item = new City();
            item.CityName = value.CityName;
            item.Image = value.Image;

            unitOfWork.CityRepository.Insert(item);
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
    [ReturnType("City")]
    public IActionResult Put(int id, [FromBody] City value)
    {
        try
        {
            City item = new City();
            item.CityId = id;
            item.CityName = value.CityName;
            item.Image = value.Image;

            unitOfWork.CityRepository.Update(item);
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
        //unitOfWork.CityRepository.Delete(id);
    }
}
