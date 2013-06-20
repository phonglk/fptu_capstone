using System.Data;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class RequestRepository : GenericRepository<Request>
    {
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
    }
}