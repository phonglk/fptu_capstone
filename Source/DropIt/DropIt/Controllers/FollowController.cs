using DropIt.DAL;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    public class FollowController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private FollowEventRepository Repository;

        public FollowController()
        {
            Repository = unitOfWork.FollowEventRepository;
        }

        [HttpPost]
        public JsonResult Event(int Id)
        {
            //try
            //{
                int UserId = WebSecurity.GetUserId(User.Identity.Name);
                Boolean IsFollow = true;
                UserFollowEvent follow = Repository.Get(f => f.UserId == UserId && f.EventId == Id).FirstOrDefault();

                if (follow == null)
                {
                    UserFollowEvent f = new UserFollowEvent
                    {
                        UserId = UserId,
                        EventId = Id
                    };
                    Repository.AddOrUpdate(f);
                }
                else
                {
                    IsFollow = false;
                    Repository.Delete(follow);
                }
                Repository.Save();

                return Json(new
                {
                    Result = "OK",
                    IsFollow = IsFollow
                });
                
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
            var follow = this.unitOfWork.FollowEventRepository.Get(x => x.UserId == UserId).ToList();
            return View(follow);
        }

    }
}
