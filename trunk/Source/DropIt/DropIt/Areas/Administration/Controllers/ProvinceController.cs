using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
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

        public class veResult{
            public string id;
            public Boolean status;
        }

        public ActionResult CheckUnique(string fieldId, string ProvinceName)
        {
            var province = unitOfWork.ProvinceRepository.Get(x => x.ProvinceName == ProvinceName).FirstOrDefault();
            if (province == null)
            {
                return Content(JsonConvert.SerializeObject(new ArrayList
                {
                    fieldId,
                    true
                }));
            }
            else
            {
                return Content(JsonConvert.SerializeObject(new ArrayList
                {
                    fieldId,
                    false,
                    "Đã có tỉnh(thành phó) "+ProvinceName
                }));
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
