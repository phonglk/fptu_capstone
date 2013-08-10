using DropIt.Common;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class EventRepository : GenericRepository<Event>
    {
        private UnitOfWork uow = new UnitOfWork();
        public EventRepository(DropItContext context)
            : base(context)
        {
             
        }

        public IEnumerable<Event> GetAvailable()
        {
            return this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate && e.Status !=(int)Statuses.Event.Disapprove);
        }

        public IEnumerable<Event> GetRequestAvailable(int UserId)
        {
            var events = uow.UserRepository.GetById(UserId).Requests.Select(t=>t.Event);
            var event2 = this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate).SkipWhile(e=>events.FirstOrDefault(x=>x.EventId == e.EventId) != null );
            return event2;
        }
    }
}