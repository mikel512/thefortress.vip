using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vDomain.Dto;
using vDomain.Entity;

namespace vDomain.Interface;

public interface IVenueService
{
    Task<IEnumerable<Venue>> Get();
    Task<IEnumerable<Venue>> GetByCity(string city);
    Task<Venue?> GetById(int id);
    Venue Save(Venue value);
    Task<Venue> SaveWithImage(VenueDto venue, IFormFile file);
    Venue Update(int id, Venue value);
    void Delete(int id);
}
