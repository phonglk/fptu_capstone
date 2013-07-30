﻿using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Routing;

namespace DropIt.DAL
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        UnitOfWork uow = new UnitOfWork();

        public TicketRepository(DropItContext context)
            : base(context)
        {

        }

        public override Ticket AddOrUpdate(Ticket entity)
        {
            Ticket UpdatedEntity = base.AddOrUpdate(entity);
            base.Save();

            if (UpdatedEntity != null) // is add new
            {
                Event Event = uow.EventRepository.GetById(UpdatedEntity.EventId);
                if (Event != null && Event.UserFollowEvents.Count > 0)
                {
                    foreach (UserFollowEvent follow in Event.UserFollowEvents)
                    {
                        Notification Noti = new Notification()
                        {
                            UserId = follow.UserId,
                            SenderId = UpdatedEntity.EventId,
                            ObjectUrl = "/Event/Details/" + UpdatedEntity.EventId,
                            ObjectType = "Event",
                            ObjectTitle = Event.EventName,
                            ActivityType = "Add",
                            IsUnread = true
                        };
                        uow.NotificationRepository.AddOrUpdate(Noti);
                    }
                    uow.NotificationRepository.Save();
                }
            }
            return null;
        }

    }
}
