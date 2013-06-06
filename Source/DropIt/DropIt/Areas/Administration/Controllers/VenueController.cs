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

namespace DropIt.Areas.Administration.Controllers
{
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
           
            return View();
        }


        public JsonResult Get()
        {
            var venues = this.unitOfWork.VenueRepository.Get();
            return Json(new
            {
                Result = venues.Select(e => new
                {
                    VenueId = e.VenueId,
                    VenueName = e.VenueName,
                    Address = e.Address,
                    ProvinceName = e.Province.ProvinceName,
                    Description = e.Description
                })
            }, JsonRequestBehavior.AllowGet);
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

        public JsonResult Delete(int id)
        {
            Venue venue = this.unitOfWork.VenueRepository.GetById(id);
            if (venue == null)
            {
                return Json(new JSONResult
                {
                    IsOK = false,
                    Reason = "Not found Id",
                });
            }
            else
            {
                try
                {
                    this.unitOfWork.VenueRepository.Delete(id);
                    this.unitOfWork.VenueRepository.Save();
                    return Json(new JSONResult
                    {
                        IsOK = true,
                        Reason = "Delete success",
                    });
                }
                catch (Exception e)
                {
                    return Json(new JSONResult
                    {
                        IsOK = false,
                        Reason = "Unexpected Error while deleting",
                    });
                }
            }
        }

        //
        // POST: /Venue/Delete/5

        

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}