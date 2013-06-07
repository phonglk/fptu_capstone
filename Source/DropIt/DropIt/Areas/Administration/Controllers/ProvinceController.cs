using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.Controllers
{
    public class ProvinceController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Venue/

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {

                var provinces = this.unitOfWork.ProvinceRepository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                var Records = provinces.Select(e => new
                {
                    ProvinceId = e.ProvinceId,
                    ProvinceName = e.ProvinceName
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = this.unitOfWork.ProvinceRepository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult Create(Province province)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedVenue = unitOfWork.ProvinceRepository.AddOrUpdate(province);
                unitOfWork.Save();
                return Json(new JSONResult(addedVenue, "Record"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(Province province)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                unitOfWork.ProvinceRepository.AddOrUpdate(province);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public JsonResult Delete(int ProvinceId)
        {
            try
            {
                this.unitOfWork.ProvinceRepository.Delete(ProvinceId);
                this.unitOfWork.ProvinceRepository.Save();

                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }

        }

        //[HttpPost]
        //public JsonResult GetProvinceOptions()
        //{
        //    try
        //    {
        //        var provinces = unitOfWork.ProvinceRepository.GetAll().Select(
        //            p => new { DisplayText = p.ProvinceName, Value = p.ProvinceId });

        //        return Json(new JSONResult(provinces, "Options"));

        //    }
        //    catch (Exception e)
        //    {

        //        return Json(new JSONResult(e));
        //    }
        //}



        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
