using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class NotificationRepository : GenericRepository<Notification>
    {
        public NotificationRepository(DropItContext context)
            : base(context)
        {

        }

    }
}