using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Dto;
using vDomain.Entity;
using vDomain.Interface;

namespace vApplication.Services;
public class VenueService : IVenueService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;

    public VenueService(TheFortressContext context, IStorageService storageService)
    {
        _unitOfWork = new UnitOfWork(context);
        _storageService = storageService;
    }


    public async Task<IEnumerable<Venue>> Get()
    {
        return await _unitOfWork.VenueRepository.Get(includeProperties: "CityFkNavigation"); 
    }

    public async Task<IEnumerable<Venue>> GetByCity(string city)
    {
        return await _unitOfWork.VenueRepository.Get(v => v.CityFkNavigation.CityName == city);
    }

    public async Task<Venue?> GetById(int id)
    {
        return await _unitOfWork.VenueRepository.GetByID(id);
    }

    public Venue Save(Venue value)
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

        _unitOfWork.VenueRepository.Insert(item);
        _unitOfWork.Save();
        return item;
    }

    public async Task<Venue> SaveWithImage(VenueDto venue, IFormFile file)
    {
        if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
        {
            throw new Exception();
        }

        string imageUrl = await _storageService.StoreImageFile(file);

        Venue item = new Venue();
        item.Hours = venue.Hours;
        item.TicketsLink = venue.TicketsLink;
        item.MenuLink = venue.MenuLink;
        item.Address = venue.Address;
        item.CityFk = venue.CityFk;
        item.Description = venue.Description;
        item.VenueName = venue.VenueName;
        item.Location = venue.Location;
        item.Picture = imageUrl;

        _unitOfWork.VenueRepository.Insert(item);
        _unitOfWork.Save();

        return item;
    }


    public Venue Update(int id, Venue value)
    {
        Venue item = new Venue();
        item.VenueId = id;
        item.Picture = value.Picture;
        item.Hours = value.Hours;
        item.TicketsLink = value.TicketsLink;
        item.MenuLink = value.MenuLink;
        item.Address = value.Address;
        item.CityFk = value.CityFk;
        item.Description = value.Description;
        item.VenueName = value.VenueName;
        item.Location = value.Location;

        _unitOfWork.VenueRepository.Update(item);
        _unitOfWork.Save();

        return item;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}
