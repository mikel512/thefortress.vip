using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Entity;
using vDomain.Interface;

namespace vApplication.Services;

public class ScraperService : IScraperService
{
    private readonly TheFortressContext _context;
    private readonly AppSettings _configuration;
    private readonly string _apiKeyHeaderName = "x-fortress-scraper-assertion";
    public ScraperService(TheFortressContext context, AppSettings configuration)
    {
        _context = context;
        _configuration = configuration;
    }   

    public async Task SaveScraperResults(List<EventConcert> concerts)
    {
        Console.WriteLine("Scraper Post");

        List<EventConcert> existing = _context.EventConcerts.AsNoTracking()
            .Where(x => x.EventDate >= DateTime.Today)
            .ToList();
        EventConcertEqualityComparer eq = new EventConcertEqualityComparer();

        // Events to update are the intersection of the two lists
        List<EventConcert> toUpdate = concerts.Intersect(existing, eq).ToList();

        // New events are the incoming events minute the intersection
        List<EventConcert> newEvents = concerts.Except(toUpdate, eq).ToList();

        // Update
        _context.EventConcerts.UpdateRange(toUpdate);
        _context.EventConcerts.AddRange(newEvents);
        await _context.SaveChangesAsync();
    }
}