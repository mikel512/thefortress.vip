using vApplication.Repository;
using vDomain.Entity;

namespace vApplication.Context;
public class UnitOfWork : IDisposable
{
    private readonly TheFortressContext context;
    private GenericRepository<EventConcert>? eventConcertRepository;
    private GenericRepository<Venue>? venueRepository;
    private GenericRepository<City>? cityRepository;
    private GenericRepository<Analytic>? analyticRepository;

    public UnitOfWork(TheFortressContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public GenericRepository<Analytic> AnalyticRepository
    {
        get
        {

            if (analyticRepository == null)
            {
                analyticRepository = new GenericRepository<Analytic>(context);
            }
            return analyticRepository;
        }
    }


    public GenericRepository<EventConcert> EventConcertRepository
    {
        get
        {

            if (eventConcertRepository == null)
            {
                eventConcertRepository = new GenericRepository<EventConcert>(context);
            }
            return eventConcertRepository;
        }
    }

    public GenericRepository<Venue> VenueRepository
    {
        get
        {

            if (venueRepository == null)
            {
                venueRepository = new GenericRepository<Venue>(context);
            }
            return venueRepository;
        }
    }
    public GenericRepository<City> CityRepository
    {
        get
        {

            if (cityRepository == null)
            {
                cityRepository = new GenericRepository<City>(context);
            }
            return cityRepository;
        }
    }

    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
