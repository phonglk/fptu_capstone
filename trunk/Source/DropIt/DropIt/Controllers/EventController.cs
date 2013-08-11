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


        public ActionResult FollowEvent()
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            var follow = this.unitOfWork.FollowEventRepository.Get(x => x.UserId == UserId).ToList();
            return View(follow.ToList());
        }

        [HttpPost]
        public ActionResult FollowEvent(int EventId = 0)
        {
            //int id = WebSecurity.GetUserId(User.Identity.Name);
            //var follow = this.unitOfWork.UserRepository.Get(u => u.UserId == id).FirstOrDefault().UserFollowEvents;
            //var ufe = this.unitOfWork.UserRepository.Get(u => u.UserId == id).FirstOrDefault().UserFollowEvents.Where(t => t.EventId == EventId).FirstOrDefault();
            //follow.Remove(ufe);
            //this.unitOfWork.Save();
            //return View(follow.ToList());

            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            UserFollowEvent follow = this.unitOfWork.FollowEventRepository.Get(r => r.UserId == UserId && r.EventId == EventId).FirstOrDefault();
            this.unitOfWork.FollowEventRepository.Delete(follow);
            var follows = this.unitOfWork.FollowEventRepository.Get(x => x.UserId == UserId).ToList();
            return View(follows.ToList());
        }
        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            return View();
        }

        public ActionResult Suggestion(String EventName, int CategoryId, DateTime HoldDate, int VenueId)
        {
            List<SuggestedEvent> suggestion = unitOfWork.EventRepository.Suggestion( EventName,  CategoryId, HoldDate, VenueId);

            return View(suggestion.Take(5).ToList());
        }
        //
        // POST: /Event/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event evt)
        {
            if (ModelState.IsValid)
            {
                this.unitOfWork.EventRepository.AddOrUpdate(evt);
                this.unitOfWork.Save();
                return RedirectToAction("List");
            }

            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        public ActionResult Edit(int id = 0)
        {
            Event evt = this.unitOfWork.EventRepository.GetById(id);
            if (evt == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event evt)
        {
            if (ModelState.IsValid)
            {
                this.unitOfWork.EventRepository.AddOrUpdate(evt);
                this.unitOfWork.EventRepository.Save();
                return RedirectToAction("List");
            }
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event evt = this.unitOfWork.EventRepository.GetById(id);
            if (evt == null)
            {
                return HttpNotFound();
            }
            return View(evt);
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
        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.unitOfWork.EventRepository.Delete(id);
            this.unitOfWork.EventRepository.Save();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}