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
    }
}