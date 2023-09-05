using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vDomain.Interface;
using vApplication.Context;
using vDomain.Attributes;
using vDomain.Entity;
using vApplication.Extensions;
using vDomain.Dto;


namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VenueController : ControllerBase
{
    private readonly IVenueService _venueService;

    public VenueController(IVenueService venueService)
    {
        _venueService = venueService;
    }

    [AllowAnonymous]
    [HttpGet]
    [ReturnType("Venue[]")]
    public async Task<IEnumerable<Venue>> Get()
    {
        return await _venueService.Get();
    }

    [AllowAnonymous]
    [HttpGet("city/{city}")]
    [ReturnType("Venue[]")]
    public async Task<IEnumerable<Venue>> GetByCity(string city)
    {
        return await _venueService.GetByCity(city);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ReturnType("Venue")]
    public async Task<Venue?> GetById(int id)
    {
        return await _venueService.GetById(id);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ReturnType("Venue")]
    public Venue Post([FromBody] Venue value)
    {
        return _venueService.Save(value);
    }

    [NTypewriterIgnore]
    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<Venue> PostWithImage()
    {
        var formRequest = Request.Form;
        IFormFile file = formRequest.Files.First();
        VenueDto? venue = JsonConvert.DeserializeObject<VenueDto>(formRequest.First().Value);

        return await _venueService.SaveWithImage(venue, file);
    }


    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [ReturnType("Venue")]
    public Venue Put(int id, [FromBody] Venue value)
    {
        return _venueService.Update(id, value);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ReturnType("any")]
    public void Delete(int id)
    {
        //unitOfWork.VenueRepository.Delete(id);
        //unitOfWork.Save(); 
    }
}
