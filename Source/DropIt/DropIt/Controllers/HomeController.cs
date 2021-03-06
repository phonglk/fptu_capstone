﻿using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using gfoidl.StringSearching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EventRepository Repository;

        public HomeController()
        {
            Repository = unitOfWork.EventRepository;
        }

        public ActionResult Index(string sortBy = "ticket")
        {
            Session["Role"] = "Event";
            var events = this.unitOfWork.EventRepository.GetAvailable();
            if(sortBy.Equals("request")){
                events = events.OrderByDescending(t => t.Requests.Count);
            }else if(sortBy.Equals("upcoming")){
                events = events.Where(e => e.HoldDate >= DateTime.Now)
                        .OrderBy(e => e.HoldDate);
            }
            else if (sortBy.Equals("selling"))
            {
                events = events.Where(e => e.Status == (int)Statuses.Event.Trading)
                        .OrderByDescending(e => e.Tickets.Where( t=>t.Status == (int)Statuses.Ticket.OnTransaction).Count());
            }else{
                events = events.OrderByDescending(t => t.Tickets.Count);
            }

            events = events.Take(10);
            ViewBag.sortBy = sortBy;
            return View(events.ToList());
        }

        public ActionResult NearEvent()
        {
            Session["Role"] = "Event";

            var topEvent = this.unitOfWork.EventRepository.Get().OrderBy(p => p.HoldDate).Where(p => p.HoldDate >= DateTime.Now).Take(10);

            return View(topEvent.ToList());
        }

        [ActionName("Buy")]
        public ActionResult BuyIndex()
        {
            Session["Role"] = "Buy";
              IEnumerable<Event> TopSellEvent = unitOfWork.EventRepository.GetAvailable().OrderByDescending(e => e.Tickets.Count).Take(5);
             // var TopRateUser = unitOfWork.UserRepository.Get().OrderByDescending(t => t.Tickets.Count).Take(5);
              return View(TopSellEvent);
        }

        [ActionName("Sell")]
        public ActionResult SellIndex()
        {
            Session["Role"] = "Sell";
            IEnumerable<Event> TopRequestedEvent = unitOfWork.EventRepository.GetAvailable().OrderByDescending(e => e.Requests.Count).Take(5);
            return View(TopRequestedEvent);
        }

        

        public ActionResult Search(string query, string sortBy = "relevant", int PageSize = 10, int StartIndex = 0)
        {
            var events = this.unitOfWork.EventRepository.Get(e => e.Status != (int)Statuses.Event.Disapprove && e.Status != (int)Statuses.Event.Delete);
            SearchResultViewModel foundEvent = null;


            if (!String.IsNullOrEmpty(query))
            {
                foundEvent = unitOfWork.EventRepository.Search(query, events, sortBy);
            }
            else
            {
                Session["Message"] = "Bạn muốn tìm kiếm gì ?";
                Session["MessageType"] = "Error";
            }

            return View(foundEvent);

        }

        [ActionName("SearchAjax")]
        public JsonResult SearchAjax(string searchText)
        {
            var events = this.unitOfWork.EventRepository.Get();
            List<SearchAjax> listevent = new List<SearchAjax>();
            if (!String.IsNullOrEmpty(searchText))
            {

                foreach (Event evt in events.ToList())
                {
                    var searchAjax = new SearchAjax
                        {
                            EventId = evt.EventId,
                            Artist = evt.Artist,
                            EventName = evt.EventName,
                            EventImage = evt.EventImage,
                            Status = evt.Status
                        };

                    if (Utils.ConvertVN(evt.EventName).ToLower().Contains(Utils.ConvertVN(searchText).ToLower()) && (evt.Status == 3 || evt.Status == 1))
                    {
                        listevent.Add(searchAjax);
                    }
                    else if (Utils.ConvertVN(evt.Artist == null ? "" : evt.Artist).ToLower().Contains(Utils.ConvertVN(searchText).ToLower()) && (evt.Status == 3 || evt.Status == 1))
                    {
                        if (!listevent.Contains(searchAjax))
                        {
                            listevent.Add(searchAjax);
                        }
                    }
                }
            }
            return Json(listevent, JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GuideForNew()
        {
            return View();
        }
    }
}
