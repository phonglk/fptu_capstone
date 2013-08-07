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
        private CategoryRepository categoryRepository;
        private VenueRepository venueRepository;
        private GenericRepository<Province> provinceRepository;
        private UserRepository userRepository;
        private TicketRepository ticketRepository;
        private RequestRepository requestRepository;
        private TicketResponseRepository responseRepository;
        private GenericRepository<UserFollowEvent> followEventRepository;
        //private GenericRepository<UserFollowUser> followUserRepository;
        //private GenericRepository<UserFollowVenue> followVenueRepository;
        private SettingRepository settingRepository;
        private TransactionRepository transactionRepository;
        private NotificationRepository notificationRepository;

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

        public CategoryRepository CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }
        public VenueRepository VenueRepository
        {
            get
            {

                if (this.venueRepository == null)
                {
                    this.venueRepository = new VenueRepository(context);
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
        //transaction
        public TransactionRepository TransactionRepository
        {
            get
            {

                if (this.transactionRepository == null)
                {
                    this.transactionRepository = new TransactionRepository(context);
                }
                return transactionRepository;
            }
        }

         //RequestTicket
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
        public TicketResponseRepository TicketResponseRepository
        {
            get
            {

                if (this.responseRepository == null)
                {
                    this.responseRepository = new TicketResponseRepository(context);
                }
                return responseRepository;
            }
        }

        //SettingRepository
        public SettingRepository SettingRepository
        {
            get
            {
                if (this.settingRepository ==null)
                {
                    this.settingRepository = new SettingRepository(context);
                }
                return settingRepository;
            }
        }

        public GenericRepository<UserFollowEvent> FollowEventRepository
        {
            get
            {

                if (this.followEventRepository == null)
                {
                    this.followEventRepository = new GenericRepository<UserFollowEvent>(context);
                }
                return followEventRepository;
            }
        }

        //public GenericRepository<UserFollowUser> FollowUserRepository
        //{
        //    get
        //    {

        //        if (this.followUserRepository == null)
        //        {
        //            this.followUserRepository = new GenericRepository<UserFollowUser>(context);
        //        }
        //        return followUserRepository;
        //    }
        //}

        //public GenericRepository<UserFollowVenue> FollowVenueRepository
        //{
        //    get
        //    {

        //        if (this.followVenueRepository == null)
        //        {
        //            this.followVenueRepository = new GenericRepository<UserFollowVenue>(context);
        //        }
        //        return followVenueRepository;
        //    }
        //}

        public NotificationRepository NotificationRepository
        {
            get
            {
                if (this.notificationRepository == null)
                {
                    this.notificationRepository = new NotificationRepository(context);
                }
                return notificationRepository;
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