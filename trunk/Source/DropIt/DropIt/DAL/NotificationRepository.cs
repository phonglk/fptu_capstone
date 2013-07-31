using DropIt.Hubs;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class NotificationRepository : GenericRepository<Notification>
    {
        UnitOfWork uow = new UnitOfWork();

        public NotificationRepository(DropItContext context)
            : base(context)
        {

        }

        public override Notification AddOrUpdate(Notification entity)
        {
            Notification UpdatedEntity = base.AddOrUpdate(entity);
            base.Save();

            if (UpdatedEntity != null) // is add new
            {
                Notification Noti = uow.NotificationRepository.GetById(UpdatedEntity.NotificationId);

                NotificationHub.Send(new
                {
                    Type = "Notification",
                    Object = new
                    {
                        Noti.ActivityType,
                        Noti.CreatedDate,
                        Noti.IsUnread,
                        Noti.ModifiedDate,
                        Noti.NotificationId,
                        Noti.ObjectTitle,
                        Noti.ObjectType,
                        Noti.ObjectUrl,
                        Noti.SenderId,
                        Noti.UserId
                    }
                }, Noti.User.UserName);
            }
            return UpdatedEntity;
        }
    }
}