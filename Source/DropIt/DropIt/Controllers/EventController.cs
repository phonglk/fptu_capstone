using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;

namespace DropIt.Controllers
{
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

        public ActionResult List()
        {
            var events = this.unitOfWork.EventRepository.Get();
            return View(events.ToList());          
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Event evt = this.unitOfWork.EventRepository.GetById(id);
            if (evt == null)
            {
                return HttpNotFound();
            }
            return View(evt);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName");
            return View();
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

        //
        // GET: /Event/Edit/5

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
            
            var Event = Repository.Get(e =>  e.EventId == EventId);

            if (Event != null)
            {
                return Json(new
                {
                    Result = "OK",
                    Records = Event.Select(e => new {
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