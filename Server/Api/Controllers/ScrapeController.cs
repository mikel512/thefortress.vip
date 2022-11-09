using Api.Attributes;
using Api.Data;
using Api.Extensions;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Api.Controllers
{

    [NTypewriterIgnore]
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        private TheFortressContext _context;
        private IConfiguration _configuration;
        public ScrapeController(TheFortressContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        /// <summary>
        /// Endpoint for the scraper to POST new results
        /// </summary>
        /// <param name="concerts"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] List<EventConcert> concerts)
        {
            Console.WriteLine("Scraper Post");
            var headerName = "x-fortress-scraper-assertion";
            var keyRef = _configuration.GetValue<string>("ScraperApiKey");
            StringValues headerValue;
            var headerExists = Request.Headers.TryGetValue(headerName, out headerValue);
            if (headerExists == false || headerValue.First() != keyRef)
            {
                return new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            List<EventConcert> existing = _context.EventConcerts.AsNoTracking()
                .Where(x => x.EventDate >= DateTime.Today)
                .ToList();
            EventConcertEqualityComparer eq = new EventConcertEqualityComparer();
            
            // Events to update are the intersection of the two lists
            List<EventConcert> toUpdate = concerts.Intersect(existing, eq).ToList();

            // New events are the incoming events minute the intersection
            List<EventConcert> newEvents = concerts.Except(toUpdate, eq).ToList();


            _context.EventConcerts.UpdateRange(toUpdate);
            _context.EventConcerts.AddRange(newEvents);
            _context.SaveChanges();

            return new OkResult();
        }
    }
}
