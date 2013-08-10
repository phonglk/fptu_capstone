using System.Data;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class TicketResponseRepository : GenericRepository<TicketResponse>
    {
        public TicketResponseRepository(DropItContext context)
            : base(context)
        {

        }
        new public TicketResponse AddOrUpdate(TicketResponse response)
        {
            var currentUser = GetCurrentUser();
            var findResponse = context.Requests.Find(response.UserId, response.EventId);

            if (findResponse == null)
            {
                var entry = context.Entry(response);
                if (entry.State == EntityState.Detached)
                {
                    var set = context.Set<TicketResponse>();
                    TicketResponse attachedEntity = set.Find(response.UserId, response.EventId, response.TicketId);
                    if (attachedEntity != null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(response);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
            }

            return response;
        }
        public TicketResponse Add(TicketResponse response)
        {
           return dbSet.Add(response);
        }
        public TicketResponse GetById(int UserId, int EventId, int TicketId)
        {
            var findResponse = context.TicketResponses.Find(UserId, EventId, TicketId);
            if (findResponse == null)
            {
                return null;
            }
            else
            {
                return findResponse;
            }
        }

        new public void Delete(int userid, int eventid, int ticketid)
        {
            TicketResponse response = new TicketResponse();
            //var findRequest = context.Requests.Find(request.UserId, request.EventId);
            var find = dbSet.Find(response.UserId, response.EventId, response.TicketId);
            Delete(response);
        }

        new public void Delete(TicketResponse response)
        {
            if (context.Entry(response).State == EntityState.Detached)
            {
                dbSet.Attach(response);
            }
            dbSet.Remove(response);
        }

    }
}