using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class RequestController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private RequestRepository Repository;

        public RequestController()
        {
            Repository = unitOfWork.RequestRepository;
        }
        //
        // GET: /Request/

        public ActionResult Index()
        {
            return View();
        }


        //Get: /ResquestTicket
        public ActionResult RequestTicket()
        {
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName");
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestTicket(RequestTicket ticket)
        {
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {               
                if (ticket.EventId==null)
                {
                    if (ticket.VenueId ==null)
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
