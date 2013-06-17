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
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Ticket ticket)
        //{
        //    ticket.Status = "1";
        //    ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
        //    if (ModelState.IsValid)
        //    {
        //        this.unitOfWork.TicketRepository.AddOrUpdate(ticket);
        //        this.unitOfWork.Save();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
        //                                     ticket.EventId);
        //    return View(ticket);
        //}

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostTicket ticket)
        {            
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                // add new venue 
                Venue venue = new Venue()
                                  {
                                      VenueName = ticket.VenueName,
                                      Address = ticket.Address,
                                      ProvinceId = ticket.ProvinceId,
                                      Status = 1                                      
                                  };
                this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                this.unitOfWork.Save();
               
                // add new event
                Event newEvent = new Event()
                                     {
                                         EventName = ticket.EventName,
                                         Status = 0,
                                         HoldDate = ticket.HoldDate,
                                         CategoryId = ticket.CategoryId,
                                         VenueId = venue.VenueId
                                     };

                this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                this.unitOfWork.Save();
                // add new ticket with EventName was created in db
                Ticket NewTicket = new Ticket()
                                       {
                                           EventId = newEvent.EventId,
                                           SellPrice = ticket.SellPrice,
                                           ReceiveMoney = ticket.ReceiveMoney,
                                           Seat = ticket.Seat,
                                           Description = ticket.Description,
                                           Status = 1,
                                           UserId = ticket.UserId
                                       };
                this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                this.unitOfWork.Save();


                string eventname = ticket.EventName;
                string venuename = ticket.VenueName;
                string address = ticket.Address;
                int provinceid = ticket.ProvinceId;
                System.DateTime holedate = ticket.HoldDate;


                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                             ticket.ProvinceId);
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", ticket.CategoryId);
            return View(ticket);
        }
    }
}
