using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class FollowController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        public FollowController()
        {
        }

        [HttpPost]
        public JsonResult Event(int Id,int FollowType)
        {
            //try
            //{
                int UserId = WebSecurity.GetUserId(User.Identity.Name);
                GenericRepository<UserFollowEvent> Repository = uow.FollowEventRepository;
                UserFollowEvent Follow = Repository.Get(f => f.UserId == UserId && f.EventId == Id).FirstOrDefault();
                if (FollowType == -1)
                {
                    if (Follow == null)
                    {
                        //return Json(new
                        //{
                        //    Result = "ERROR",
                        //    Message = "UserDoesNotFollow",
                        //    FollowType = -1
                        //});
                    }
                    else
                    {
                        Repository.Delete(Follow);
                        Repository.Save();
                        
                    }
                    return Json(new
                    {
                        Result = "OK",
                        FollowType = -1
                    });

                }
                else
                {
                    if (Follow == null)
                    {
                        Follow = new UserFollowEvent
                        {
                            UserId = UserId,
                            EventId = Id
                        };
                    }
                    Follow.FollowType = FollowType;
                    Repository.AddOrUpdate(Follow);
                    Repository.Save();

                    return Json(new
                    {
                        Result = "OK",
                        FollowType = FollowType
                    });
                }
                

                
                
            //}
            //catch (Exception e)
            //{
            //    return Json(new
            //    {
            //        Result = "ERROR",
            //        Message = e.Message
            //    });
            //}
        }

        public ActionResult Events()
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            var follow = uow.FollowEventRepository.Get(x => x.UserId == UserId).ToList();
            return View(follow);
        }

    }
}
