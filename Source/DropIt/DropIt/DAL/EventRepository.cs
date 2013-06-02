using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.Data;


namespace DropIt.DAL
{
    public class EventRepository : BaseRepository,IEventReposity
    {
        public EventRepository(DropItContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Event> GetAll()
        {
            return ctx.Events.ToList();
        }

        public Event GetById(int id)
        {
            return ctx.Events.Find(id);
        }

        public void Delete(int id)
        {
            Event Evt = ctx.Events.Find(id);
            ctx.Events.Remove(Evt);
        }

        public void AddOrUpdate(Event Event)
        {
            DateTime now = DateTime.Now;

            if (Event.EventId == default(int))
            {
                Event.CreatedDate = Event.ModifiedDate = now;
                ctx.Events.Add(Event);
            }
            else
            {
                Event.ModifiedDate = now;
                ctx.Entry(Event).State = EntityState.Modified;
            }
        }

        
    }
}