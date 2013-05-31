using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;

namespace DropIt.Controllers
{
    public class EventController : Controller
    {
        private Drop_ItContext db = new Drop_ItContext();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Category).Include(e => e.Venue);
            return View(events.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Event evt= db.Events.Find(id);
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
                db.Events.Add(evt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event evt= db.Events.Find(id);
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
                db.Entry(evt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", evt.CategoryId);
            ViewBag.VenueId = new SelectList(db.Venues, "VenueId", "VenueName", evt.VenueId);
            return View(evt);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event evt= db.Events.Find(id);
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
            Event evt= db.Events.Find(id);
            db.Events.Remove(evt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}