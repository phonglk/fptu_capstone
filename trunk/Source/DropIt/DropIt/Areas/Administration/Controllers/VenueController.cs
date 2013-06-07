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

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public JsonResult List(int ProvinceId = -1,int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {

                var venues = this.unitOfWork.VenueRepository.JTGet(jtStartIndex,jtPageSize,jtSorting);

                if (ProvinceId > -1)
                {
                    venues = venues.Where(x => x.ProvinceId == ProvinceId);
                }

                var Records = venues.Select(e => new
                {
                    VenueId = e.VenueId,
                    VenueName = e.VenueName,
                    Address = e.Address,
                    ProvinceId = e.ProvinceId,
                    Description = e.Description
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = this.unitOfWork.VenueRepository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult Create(Venue venue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedVenue = unitOfWork.VenueRepository.AddOrUpdate(venue);
                unitOfWork.Save();
                return Json(new JSONResult(addedVenue,"Record"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(Venue venue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                unitOfWork.VenueRepository.AddOrUpdate(venue);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public JsonResult Delete(int VenueId)
        {
            try
            {
                this.unitOfWork.VenueRepository.Delete(VenueId);
                this.unitOfWork.VenueRepository.Save();

                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
            
        }

        [HttpPost]
        public JsonResult GetProvinceOptions()
        {
            try
            {
                var provinces = unitOfWork.ProvinceRepository.GetAll().Select(
                    p => new { DisplayText = p.ProvinceName, Value = p.ProvinceId });

                    return Json(new JSONResult(provinces,"Options"));

            }
            catch (Exception e)
            {

                return Json(new JSONResult(e));
            }
        }

        

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}