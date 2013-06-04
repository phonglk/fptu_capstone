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
        private DropItContext db = new DropItContext();
        private BaseRepository<Event> eventRepository;
        //
        // GET: /Event/

        public EventController()
        {
            this.eventRepository = new BaseRepository<Event>(db);
        }

        public ActionResult List()
        {
            var events = eventRepository.GetAll();
            return View(events.ToList());          
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Event evt = eventRepository.GetById(id);
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
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName");
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
                eventRepository.AddOrUpdate(evt);
                eventRepository.Save();
                return RedirectToAction("List");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event evt = eventRepository.GetById(id);
            if (evt == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName", evt.VenueId);
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
                eventRepository.AddOrUpdate(evt);
                eventRepository.Save();
                return RedirectToAction("List");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event evt = eventRepository.GetById(id);
            if (evt == null)
            {
                return HttpNotFound();
            }
            return View(evt);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventRepository.Delete(id);
            eventRepository.Save();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}