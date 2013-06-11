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
        private EventRepository eventRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Venue> venueRepository;
        private GenericRepository<Province> provinceRepository;
        private UserRepository userRepository;


        public EventRepository EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new EventRepository(context);
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

        public GenericRepository<Province> ProvinceRepository
        {
            get
            {

                if (this.provinceRepository == null)
                {
                    this.provinceRepository = new GenericRepository<Province>(context);
                }
                return provinceRepository;
            }
        }

        // UserDetal 
        public UserRepository UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
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