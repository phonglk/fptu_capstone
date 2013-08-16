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
using WebMatrix.WebData;
using DropIt.Filters;
using DropIt.ViewModels;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class EventController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EventRepository Repository;
        //
        // GET: /Event/

        public EventController()
        {
            Repository = unitOfWork.EventRepository;
        }

        public ActionResult Index(int PageSize = 10, int StartIndex = 0,int CategoryId = -1)
        {
            
            var events = this.unitOfWork.EventRepository.Get(e => e.Status == (int)Statuses.Event.Approve || e.Status == (int)Statuses.Event.Trading);
            if (CategoryId != -1)
            {
                events = events.Where(e => e.CategoryId == CategoryId || (e.Category.Category2!= null && e.Category.Category2.CategoryId == CategoryId));
                
            }
            ViewBag.TotalCount = events.Count();
            events = events.Skip(StartIndex).Take(PageSize).ToList();
           
            return View(events.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Event evt = this.unitOfWork.EventRepository.GetById(id);
            String defaultSorting = "SellPrice ASC";
            if (Request["Sorting"] == null)
            {
                ViewBag.Sorting = defaultSorting;
            }
            else
            {
                ViewBag.Sorting = Request["Sorting"];
            }
            evt.Tickets = evt.Tickets.Where(t => t.Status == (int)Statuses.Ticket.Ready).ToList();
            dynamic Helper = unitOfWork.TicketRepository.ControllerHelper(Request, evt.Tickets,defaultSorting);
            evt.Tickets = Helper.Records;
            evt.Requests = (ICollection<Request>)evt.Requests.OrderBy(r => r.CreatedDate).ToList();
            
            if (evt == null)
            {
                return HttpNotFound();
            }
            ViewBag.TotalRecordCount = Helper.Paging.TotalRecordCount;
            ViewBag.StartIndex = Helper.Paging.StartIndex;
            ViewBag.PageSize = Helper.Paging.PageSize;
            return View(evt);
        }

        public ActionResult Suggestion(String EventName, int CategoryId, DateTime HoldDate, int VenueId)
        {
            List<SuggestedEvent> suggestion = unitOfWork.EventRepository.Suggestion( EventName,  CategoryId, HoldDate, VenueId);

            return View(suggestion.Take(5).ToList());
        }

        [HttpPost]
        public JsonResult getInfo(int EventId)
        {

            var Event = Repository.Get(e => e.EventId == EventId);

            if (Event != null)
            {
                return Json(new
                {
                    Result = "OK",
                    Records = Event.Select(e => new
                    {
                        e.Venue.VenueName,
                        e.Venue.VenueId,
                        e.Venue.Address,
                        e.Venue.Province.ProvinceId,
                        e.Venue.Province.ProvinceName,
                        e.CategoryId,
                        e.HoldDate
                    })
                });
            }
            else
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = "Event not found"
                });
            }

        }

        public ActionResult Image(int Id)
        {
            var Event = Repository.GetById(Id);
            String ImagePath = Settings.get("DefaultEventImage");
            if (Event != null)
            {
                if (Event.EventImage != null)
                {
                    ImagePath = Event.EventImage;
                }
            }

            return base.File(ImagePath, "image/jpeg");

        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Count()
        {
            try
            {
                return Json(new
                {
                    Result = "OK",
                    Count = Repository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Count = 0
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}