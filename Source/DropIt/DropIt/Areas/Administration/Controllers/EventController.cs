using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;
using DropIt.Common;

namespace DropIt.Areas.Administration.Controllers
{
    public class EventController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Event/

        public EventController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult List()
        //{
        //    var events = this.unitOfWork.EventRepository.Get();
        //    return View(events.ToList());          
        //}

        //public JsonResult Get()
        //{
        //    var events = this.unitOfWork.EventRepository.Get();
        //    return Json(new
        //    {
        //        Result = events.Select(e => new {
        //            EventId = e.EventId,
        //            EventName = e.EventName,
        //            Artist = e.Artist,
        //            HoldDate = e.HoldDate,
        //            Description = e.Description,
        //            Status = e.Status,
        //            Category = e.Category.CategoryName,
        //            Venue = e.Venue.VenueName,
        //            RequestCount = e.Requests.Count,
        //            FollowerCount = e.UserFollowEvents.Count,
        //            CreatedDate = e.CreatedDate,
        //            ModifiedDate = e.ModifiedDate
        //        })
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}