using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;
using DropIt.Filters;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class VenueController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Venue/

        public VenueController()
        {
            
        }

        public ActionResult Index()
        {
            //var venues = db.Venues.Include(v => v.Province);
            //return View(venues.ToList());
            var venue = this.unitOfWork.VenueRepository.Get();
            return View(venue.ToList());
        }

        //
        // GET: /Venue/Details/5

        public ActionResult Details(int id = 0)
        {
            Venue venue = this.unitOfWork.VenueRepository.GetById(id);
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
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.VenueRepository.Get(), "ProvinceId", "ProvinceName");
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
                this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                this.unitOfWork.VenueRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(this.unitOfWork.VenueRepository.Get(), "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        //
        // GET: /Venue/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Venue venue = this.unitOfWork.VenueRepository.GetById(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.VenueRepository.Get(), "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        [HttpPost]
        public JsonResult getInfo(int VenueId)
        {

           var Venue = unitOfWork.VenueRepository.Get(e => e.VenueId == VenueId);

            if (Venue != null)
            {
                return Json(new
                {
                    Result = "OK",
                    Records = Venue.Select(e => new
                    {
                        e.Address,
                        e.Province.ProvinceId,
                        e.Province.ProvinceName
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
        // POST: /Venue/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(venue).State = EntityState.Modified;
                //db.SaveChanges();
                this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                this.unitOfWork.VenueRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.VenueRepository.Get(), "ProvinceId", "ProvinceName", venue.ProvinceId);
            return View(venue);
        }

        //
        // GET: /Venue/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Venue venue = this.unitOfWork.VenueRepository.GetById(id);
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
            this.unitOfWork.VenueRepository.Delete(id);
            this.unitOfWork.VenueRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}