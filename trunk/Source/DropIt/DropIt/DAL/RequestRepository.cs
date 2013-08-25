using System.Data;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Common;

namespace DropIt.DAL
{
    public class RequestRepository : GenericRepository<Request>
    {

        UnitOfWork uow = new UnitOfWork();
        public RequestRepository(DropItContext context)
            : base(context)
        {
            
        }
        new public Request AddOrUpdate(Request request)
        {
            DateTime now = DateTime.Now;
            var currentUser = GetCurrentUser();
            var findRequest = context.Requests.Find(request.UserId, request.EventId);
            
            if (findRequest == null)
            {
                request.CreatedDate = now;
                request.ModifiedDate = now;
                context.Requests.Add(request);

                Event Event = uow.EventRepository.GetById(request.EventId);
                if (Event != null && Event.UserFollowEvents.Count > 0)
                {
                    foreach (UserFollowEvent follow in Event.UserFollowEvents)
                    {
                        if (follow.UserId == request.UserId || follow.FollowType == (int)Statuses.FollowType.Sell)
                        {
                            continue;
                        }
                        Notification Noti = new Notification()
                        {
                            UserId = follow.UserId,
                            SenderId = request.EventId,
                            ObjectUrl = "/Event/Details/" + request.EventId+"#request",
                            ObjectType = "Event",
                            ObjectTitle = Event.EventName,
                            ActivityType = "Request",
                            IsUnread = true
                        };
                        uow.NotificationRepository.AddOrUpdate(Noti);
                    }
                    uow.NotificationRepository.Save();
                }
            }
            else
            {
                request.CreatedDate = context.Requests.Find(request.UserId, request.EventId).CreatedDate;
                request.ModifiedDate = now;
                var entry = context.Entry(request);
                if (entry.State==EntityState.Detached)
                {
                    var set = context.Set<Request>();
                    Request attachedEntity = set.Find(request.UserId, request.EventId);
                    if(attachedEntity!=null)
                    {
                        context.Entry(attachedEntity).CurrentValues.SetValues(request);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
            }
            
            return request;
        }

        public Request GetById(int UserId, int EventId)
        {
            var findRequest = context.Requests.Find(UserId, EventId);
            if (findRequest == null)
            {
                return null;
            }
            else
            {
                return findRequest;
            }
        }

        new public void Delete(int userid, int eventid) 
        {
            Request request = new Request();
            //var findRequest = context.Requests.Find(request.UserId, request.EventId);
            var find = dbSet.Find(request.UserId, request.EventId);
            Delete(request);
        }

        new public void Delete(Request request)
        {
            if (context.Entry(request).State == EntityState.Detached)
            {
                dbSet.Attach(request);
            }
            dbSet.Remove(request);
        }


    }
}