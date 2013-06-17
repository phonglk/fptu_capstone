using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            return View();
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostTicket ticket)
        {            
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if(ticket.EventId==null)
                {
                    if (ticket.VenueId == null)
                    {
                        // add new venue 
                        Venue venue = new Venue()
                        {
                            VenueName = ticket.VenueName,
                            Address = ticket.Address,
                            ProvinceId = (int)ticket.ProvinceId,
                            Status = 1
                        };
                        this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                        this.unitOfWork.Save();

                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = 0,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = (int)ticket.CategoryId,
                            VenueId = venue.VenueId
                        };

                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new ticket
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
                        Debug.WriteLine("khong co venueid");
                    }

                    else //if(ticket.EventId!=null)
                    {
                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = 0,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = (int)ticket.CategoryId,
                            VenueId = (int)ticket.VenueId
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
                        Debug.WriteLine("12345");
                    }
                }
                else
                {
                    Ticket NewTicket = new Ticket()
                    {
                        EventId = (int)ticket.EventId,
                        SellPrice = ticket.SellPrice,
                        ReceiveMoney = ticket.ReceiveMoney,
                        Seat = ticket.Seat,
                        Description = ticket.Description,
                        Status = 1,
                        UserId = ticket.UserId
                    };
                    this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                    this.unitOfWork.Save();
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                             ticket.ProvinceId);
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", ticket.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", ticket.VenueId);
            return View(ticket);
        }
    }
}
