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
        public EventRepository(DropItContext context)
            : base(context)
        {
             
        }

        public IEnumerable<Event> GetAvailable()
        {
            return this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate);
        }
    }
}