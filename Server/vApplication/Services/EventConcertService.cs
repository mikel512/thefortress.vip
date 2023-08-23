using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vApplication.Context;
using vApplication.Extensions;
using vDomain.Entity;
using vDomain.Forms;
using vDomain.Interface;

namespace vApplication.Services;

public class EventConcertService : IEventConcertService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;

    public EventConcertService(TheFortressContext context, IStorageService storageService)
    {
        _unitOfWork = new UnitOfWork(context);
        _storageService = storageService;
    }

    public async Task<List<EventConcert>> ListPublic()
    {
        var items = await _unitOfWork.EventConcertRepository
        .Get(e => e.EventDate.Date >= DateTime.Today.Date,
            orderBy: e => e.OrderBy(x => x.EventDate),
            includeProperties: "VenueFkNavigation");
        return items.ToList();
    }

    public async Task<List<EventConcert>> ListByCityPublic(string cityName)
    {
        var items = await _unitOfWork.EventConcertRepository
            .Get(e => e.VenueFkNavigation!.CityFkNavigation.CityName == cityName && e.EventDate >= DateTime.Today.AddDays(-1),
                orderBy: e => e.OrderBy(x => x.EventDate),
                includeProperties: "VenueFkNavigation");
        return items.ToList();
    }

    public async Task<List<EventConcert>> ListByVenuePublic(int venueId)
    {

        var items = await _unitOfWork.EventConcertRepository
            .Get(e => e.VenueFk == venueId && e.EventDate >= DateTime.Today.AddDays(-1),
                orderBy: e => e.OrderBy(x => x.EventDate),
                includeProperties: "VenueFkNavigation");
        return items.ToList();
    }

    public EventConcert Save(EventConcert eventConcert)
    {
        EventConcert item = new EventConcert();
        item.EventName = eventConcert.EventName;
        item.EventDate = eventConcert.EventDate;
        item.EventTime = eventConcert.EventTime;
        item.Details = eventConcert.Details;
        item.Tickets = eventConcert.Tickets;
        item.Flyer = eventConcert.Flyer;
        item.Status = eventConcert.Status;
        item.VenueFk = eventConcert.VenueFk;

        _unitOfWork.EventConcertRepository.Insert(item);
        _unitOfWork.Save();

        return item;
    }

    public async Task<EventConcert> SaveWithFlyer(StringValues request, IFormFile? file)
    {

        // validate file extension
        if (file == null)
        {
            throw new Exception();

        }
        if (!file.ValidateFileExtension("jpg", "png", "jpeg"))
        {
            throw new Exception();
        }

        EventConcertFormModel? concert = JsonConvert.DeserializeObject<EventConcertFormModel>(request);
        string flyerUrl = await _storageService.StoreImageFile(file);

        EventConcert item = new EventConcert();
        item.EventName = concert.EventName;
        item.EventDate = concert.EventDate;
        item.EventTime = concert.EventTime;
        item.Details = concert.Details;
        item.Tickets = concert.TicketsUrl;
        item.Flyer = flyerUrl;
        item.VenueFk = concert.VenueFk;

        _unitOfWork.EventConcertRepository.Insert(item);
        _unitOfWork.Save();
        return item;
    }

    public EventConcert GetById(int id)
    {
        var item = _unitOfWork.EventConcertRepository
            .Get(e => e.EventConcertId == id,
                includeProperties: "VenueFkNavigation").Result.FirstOrDefault() ?? new EventConcert();
        return item; 
    }
}