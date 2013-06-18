using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
        private TicketRepository ticketRepository;
        private RequestRepository requestRepository;


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

        //Ticket
        public TicketRepository TicketRepository
        {
            get
            {

                if (this.ticketRepository == null)
                {
                    this.ticketRepository = new TicketRepository(context);
                }
                return ticketRepository;
            }
        }

        // RequestTicket
        public RequestRepository RequestRepository
        {
            get
            {

                if (this.requestRepository == null)
                {
                    this.requestRepository = new RequestRepository(context);
                }
                return requestRepository;
            }
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
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