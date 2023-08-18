using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Linq;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Attributes;
using vDomain.Entity;
using vDomain.Interface;

namespace Api.Controllers;

[NTypewriterIgnore]
[Route("api/[controller]")]
[ApiController]
public class ScrapeController : ControllerBase
{
    private readonly AppSettings _configuration;
    private readonly IScraperService _scraperService;
    private readonly string _apiKeyHeaderName = "x-fortress-scraper-assertion";

    public ScrapeController(AppSettings configuration, IScraperService scraperService)
    {
        _configuration = configuration;
        _scraperService = scraperService;
    }


    /// <summary>
    /// Endpoint for the scraper to POST new results. Public endpoint protected by private key.
    /// </summary>
    /// <param name="concerts"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] List<EventConcert> concerts)
    {
        var keyRef = _configuration.ScraperApiKey;
        var headerExists = Request.Headers.TryGetValue(_apiKeyHeaderName, out StringValues headerValue);
        if (headerExists == false || headerValue.First() != keyRef)
        {
            return new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }

        await _scraperService.SaveScraperResults(concerts);

        return new OkResult();
    }
}
