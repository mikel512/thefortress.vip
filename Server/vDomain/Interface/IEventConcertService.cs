using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vDomain.Entity;

namespace vDomain.Interface;

public interface IEventConcertService
{
    EventConcert GetById(int id);
    Task<List<EventConcert>> ListPublic();
    Task<List<EventConcert>> ListByCityPublic(string cityName);
    Task<List<EventConcert>> ListByVenuePublic(int venueId);
    EventConcert Save(EventConcert eventConcert);
    Task<EventConcert> SaveWithFlyer(StringValues request, IFormFile? file);
}