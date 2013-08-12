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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}