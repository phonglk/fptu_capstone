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
    public class VenueController : Controller
    {
        private DropItContext db = new DropItContext();

        //
        // GET: /Venue/

        public ActionResult Index()
        {
            var venues = db.Venues.Include(v => v.Province);
            return View(venues.ToList());
        }

        //
        // GET: /Venue/Details/5

        public ActionResult Details(int id = 0)
        {
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //
        // GET: /Venue/Create

        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName");
            return View();
        }

        //
        // POST: /Venue/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Venues.Add(venue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        //
        // GET: /Venue/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        //
        // POST: /Venue/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        //
        // GET: /Venue/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //
        // POST: /Venue/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = db.Venues.Find(id);
            db.Venues.Remove(venue);
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