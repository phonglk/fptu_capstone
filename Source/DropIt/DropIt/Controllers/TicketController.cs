using DropIt.Common;
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
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostTicket ticket)
        {            
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (Request.Form["CreateEvent"] != null) // create new event
                {
                    if (Request.Form["CreateVenue"] != null) // create new venue
                    {
                        // add new venue 
                        Venue venue = new Venue()
                        {
                            VenueName = ticket.VenueName,
                            Address = ticket.Address,
                            ProvinceId = (int)ticket.ProvinceId,
                            Status = (int)Statuses.Venue.Disapprove
                        };
                        this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                        this.unitOfWork.Save();

                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = (int)Statuses.Event.Disapprove,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = venue.VenueId        
                        };

                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new ticket
                        Ticket NewTicket = new Ticket()
                        {
                            EventId = newEvent.EventId,
                            SellPrice = ticket.SellPrice,
                            ReceiveMoney = (int)ticket.SellPrice*0.97,
                            Seat = ticket.Seat,
                            Description = ticket.Description,
                            Status = (int)Statuses.Ticket.Disapprove,
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
                            Status = (int)Statuses.Event.Disapprove,
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
                            Status = (int)Statuses.Ticket.Disapprove,
                            UserId = ticket.UserId
                        };
                        this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                        this.unitOfWork.Save();
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
                        Status = (int)Statuses.Ticket.Approve,
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

        //Get: /
        public ActionResult Buy(int Id)
        {
            ViewBag.TicketId = Id;
            //ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            //ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(BuyTicket buyTicket)
        {
            if (buyTicket.TranType==1)
            {
                buyTicket.TranType = (int)Statuses.TranType.HoldPayment;
            }
            else
            {
                buyTicket.TranType = (int) Statuses.TranType.InstantPayment;
            }
            buyTicket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            Ticket ticket = unitOfWork.TicketRepository.Get(u => u.TicketId == buyTicket.TicketId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Ticket newticket = new Ticket()
                {
                    TicketId = buyTicket.TicketId,
                    TranUserId = buyTicket.UserId,
                    TranFullName = buyTicket.TranFullName,
                    TranAddress = buyTicket.TranAddress,
                    TranType = buyTicket.TranType,
                    TranStatus = (int)Statuses.BuyTicket.Unpaid,
                    EventId = ticket.EventId,
                    UserId = ticket.UserId,
                    SellPrice = ticket.SellPrice,
                    ReceiveMoney = ticket.ReceiveMoney,
                    Seat = ticket.Seat,
                    Status = ticket.Status,
                    Description = ticket.Description,
                    CreatedDate = ticket.CreatedDate,
                    TranCreatedDate = DateTime.Now,
                    TranModifiedDate = DateTime.Now,
                    TranDescription = buyTicket.TranDescription
                };
                this.unitOfWork.TicketRepository.AddOrUpdate(newticket);
                this.unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }
            return View(buyTicket);
        }

        //Get: /ResquestTicket
        [ActionName("Request")]
        public ActionResult RequestTicket()
        {
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName");
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ActionName("Request")]
        [ValidateAntiForgeryToken]
        public ActionResult RequestTicket(RequestTicket ticket)
        {
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (Request.Form["CreateEvent"] != null)
                {
                    if (Request.Form["CreateVenue"] != null)
                    {
                        //add new venue
                        Venue newVenue = new Venue()
                        {
                            VenueName = ticket.VenueName,
                            Address = ticket.Address,
                            ProvinceId = (int)ticket.ProvinceId,
                            Status = 1
                        };
                        this.unitOfWork.VenueRepository.AddOrUpdate(newVenue);
                        this.unitOfWork.Save();

                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = 0,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = newVenue.VenueId
                        };
                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new request
                        Request newrequest = new Request()
                        {
                            UserId = ticket.UserId,
                            EventId = newEvent.EventId,
                            Status = 1,
                            Description = ticket.Description
                        };
                        this.unitOfWork.RequestRepository.AddOrUpdate(newrequest);
                        this.unitOfWork.Save();
                    }
                    else
                    {
                        // add new Event
                        Event newevent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = 0,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = (int)ticket.VenueId
                        };
                        this.unitOfWork.EventRepository.AddOrUpdate(newevent);
                        this.unitOfWork.Save();

                        // add new Request
                        Request newRequest = new Request()
                        {
                            UserId = ticket.UserId,
                            EventId = newevent.EventId,
                            Description = ticket.Description,
                            Status = 1
                        };
                    }
                }
                else
                {
                    // add to request
                    Request request = new Request()
                    {
                        UserId = ticket.UserId,
                        EventId = (int)ticket.EventId,
                        Status = 1,
                        Description = ticket.Description
                    };
                    this.unitOfWork.RequestRepository.AddOrUpdate(request);
                    this.unitOfWork.Save();
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                             ticket.ProvinceId);
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", ticket.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", ticket.VenueId);
            return View();
        }
    }
}
