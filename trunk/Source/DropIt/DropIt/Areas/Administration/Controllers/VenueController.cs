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
        private GenericRepository<Venue> Repository;
        //
        // GET: /Venue/

        public VenueController()
        {
            Repository = unitOfWork.VenueRepository;
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {

                var records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                var Records = records.Select(e => new
                {
                    VenueId = e.VenueId,
                    VenueName = e.VenueName,
                    Address = e.Address,
                    ProvinceId = e.ProvinceId,
                    Description = e.Description
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = Repository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult Create(Venue Venue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedRecord = Repository.AddOrUpdate(Venue);
                unitOfWork.Save();
                return Json(new JSONResult(addedRecord, "Record"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(Venue Venue)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                Repository.AddOrUpdate(Venue);
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
                Repository.Delete(VenueId);
                unitOfWork.Save();

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

        [HttpPost]
        public JsonResult GetOptions()
        {
            try
            {
                var Records = Repository.GetAll().Select(
                    p => new { DisplayText = p.VenueName, Value = p.VenueId });
                return Json(new JSONResult(Records, "Options"));

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