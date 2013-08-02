using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Common;
using WebMatrix.WebData;
using DropIt.Models;
using DropIt.Filters;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class NotificationController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();
        private NotificationRepository Repository;

        public NotificationController()
        {
            Repository = uow.NotificationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReadAll(int FollowType = 2)
        {

            try
            {
                int UserId = WebSecurity.GetUserId(User.Identity.Name);

                var records = Repository.Get(n => n.IsUnread == true);
                if (FollowType == (int)Statuses.FollowType.Buy)
                {
                    records = records.Where(n => n.ActivityType.Equals("Add"));
                }
                else if (FollowType == (int)Statuses.FollowType.Sell)
                {
                    records = records.Where(n => n.ActivityType.Equals("Request"));
                }
                else
                {

                }

                foreach (Notification record in records)
                {
                    record.IsUnread = false;
                    Repository.AddOrUpdate(record);
                }
                Repository.Save();

                return Json(new
                    {
                        Result = "OK"
                    });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult List(int FollowType = 2,String Object="*",Nullable<Boolean> IsUnread = null,int jTStartIndex = 0,int FromId = 0,int jtPageSize = 10,String jtSorting = "CreatedDate DESC")
        {
            try
            {

                int UserId = WebSecurity.GetUserId(User.Identity.Name);
                var records = Repository.Get();
                if (IsUnread != null)
                {
                    records = records.Where(n => n.IsUnread == IsUnread);
                }
                if (FollowType == (int)Statuses.FollowType.Buy)
                {
                    records = records.Where(n => n.ActivityType.Equals("Add"));
                }
                if (FollowType == (int)Statuses.FollowType.Sell)
                {
                    records = records.Where(n => n.ActivityType.Equals("Request"));
                }

                if (Object.Equals("*"))
                {

                }
                else
                {
                    records = records.Where(n => n.ObjectType.Equals(Object));
                }

                records = records.Where(n => n.UserId == UserId || n.UserId == null || n.UserId == -1);
                int unreadCount = records.Where(n => n.IsUnread == true).Count();

                records = records.OrderBy(jtSorting);

                if (FromId > 0)
                {
                    records = records.Where(n => n.NotificationId < FromId);
                }else{
                    records = records.Skip(jTStartIndex);
                }

                records = records.Take(jtPageSize);

                //records = Repository.JT(records, jTStartIndex, jtPageSize, jtSorting);

                return Json(new
                {
                    Result = "OK",
                    Records = records.Select(n => new
                    {
                        n.NotificationId,
                        n.UserId,
                        n.SenderId,
                        n.ObjectType,
                        n.ObjectTitle,
                        n.ActivityType,
                        n.ObjectUrl,
                        n.IsUnread,
                        n.CreatedDate,
                        n.ModifiedDate
                    }),
                    UnreadCount = unreadCount
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "Error",
                    Message = e.Message
                });
            }
        }
    }
}
