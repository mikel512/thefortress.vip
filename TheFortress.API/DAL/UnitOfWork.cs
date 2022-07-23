﻿using System;
using TheFortress.API.Data;
using TheFortress.API.Models;

namespace TheFortress.API.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly TheFortressContext context;
        private GenericRepository<EventConcert>? eventConcertRepository;
        private GenericRepository<Venue>? venueRepository;
        private GenericRepository<City>? cityRepository;
        private GenericRepository<AppUser>? appUserRepository;

        public UnitOfWork(TheFortressContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public GenericRepository<AppUser> AppUserRepository
        {
            get
            {

                if (this.appUserRepository == null)
                {
                    this.appUserRepository = new GenericRepository<AppUser>(context);
                }
                return appUserRepository;
            }
        }

        public GenericRepository<EventConcert> EventConcertRepository
        {
            get
            {

                if (this.eventConcertRepository == null)
                {
                    this.eventConcertRepository = new GenericRepository<EventConcert>(context);
                }
                return eventConcertRepository;
            }
        }

        public GenericRepository<Venue> VenueRepository
        {
            get
            {

                if (this.venueRepository == null)
                {
                    this.venueRepository = new GenericRepository<Venue>(context);
                }
                return venueRepository;
            }
        }
        public GenericRepository<City> CityRepository
        {
            get
            {

                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }

        public async void Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual async void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
