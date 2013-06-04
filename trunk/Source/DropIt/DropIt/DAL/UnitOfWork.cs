using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;

namespace DropIt.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DropItContext context = new DropItContext();
        private GenericRepository<Event> eventRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Venue> venueRepository;

        public GenericRepository<Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
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

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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