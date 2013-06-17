using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TicketController : Controller
    {
        DropItContext db = new DropItContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;
        private EventRepository eventRepository;
        private GenericRepository<Province> provinceRepository;
        //
        // GET: /Ticket/

        public TicketController()
        {
            Repository = unitOfWork.TicketRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName");

            // them moi vao test provinceid
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            ticket.Status = "1";
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                this.unitOfWork.TicketRepository.AddOrUpdate(ticket);
                this.unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            return View(ticket);
        }

        //[HttpPost]
        //public JsonResult getEventInfo(int EventId)
        //{

        //    var temp = from tk in db.Tickets
        //               join ev in db.Events on tk.EventId equals ev.EventId
        //               join vn in db.Venues on ev.VenueId equals vn.VenueId
        //               where EventId == ev.VenueId
        //               select new
        //                          {                                      
        //                              vn.VenueName,
        //                              vn.Address,
        //                              vn.ProvinceId,
        //                              ev.HoldDate
        //                          };

        //    return Json(temp, JsonRequestBehavior.AllowGet);

        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(PostTicket ticket)
        //{
        //    ticket.Status = "1";
        //    ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        Venue venue = new Venue();
        //        venue.VenueName = ticket.VenueName;
        //        venue.Address = ticket.Address;
        //        venue.ProvinceId = ticket.ProvinceId;
        //        venue.Status = 1;
        //        db.SaveChanges();
                
        //        string eventname = ticket.EventName;
        //        string venuename = ticket.VenueName;
        //        string address = ticket.Address;
        //        int provinceid = ticket.ProvinceId;
        //        System.DateTime holedate = ticket.HoldDate;
                
                
        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
        //                                     ticket.ProvinceId);
        //    return View(ticket);
        //}
    }
}
