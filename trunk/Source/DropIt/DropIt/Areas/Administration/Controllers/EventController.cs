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
using System.Diagnostics;

namespace DropIt.Areas.Administration.Controllers
{
    public class EventController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EventRepository Repository;
        //
        // GET: /Venue/

        public EventController()
        {
            Repository = unitOfWork.EventRepository;
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
                    EventId = e.EventId,
                    EventName = e.EventName,
                    EventImage = e.EventImage,
                    Artist = e.Artist,
                    HoldDate = e.HoldDate,
                    Description = e.Description,
                    Status = e.Status,
                    CategoryId = e.CategoryId,
                    VenueId = e.VenueId
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
        public JsonResult Create(Event Event,HttpPostedFileBase EventImage)
        {

            if (EventImage.ContentLength <= 5000000 && EventImage.ContentType.IndexOf("image") > -1)
            {
                Event.EventImage = Uploader.Upload(EventImage, this).ToString();
            }
            else
            {
                return Json(new JSONResult()
                {
                    Result = "ERROR",
                    Message = "Phải là hình ảnh và kích thước < 5MB"
                });
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedRecord = Repository.AddOrUpdate(Event);
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
        public JsonResult Update(Event Event, HttpPostedFileBase EventImage)
        {
            if (EventImage != null)
            {
                if (EventImage.ContentLength <= 5000000 && EventImage.ContentType.IndexOf("image") > -1)
                {
                    Event.EventImage = Uploader.Upload(EventImage, this).ToString();
                }
                else
                {
                    return Json(new JSONResult()
                    {
                        Result = "ERROR",
                        Message = "Phải là hình ảnh và kích thước < 5MB"
                    });
                }
            }
            else
            {
                // NoUpload use old data
                Event.EventImage = Repository.Get(evt => evt.EventId == Event.EventId).FirstOrDefault().EventImage;
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                Repository.AddOrUpdate(Event);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public JsonResult Delete(int EventId)
        {
            try
            {
                Repository.Delete(EventId);
                unitOfWork.Save();

                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }

        }
        [HttpPost]
        public JsonResult GetEventOption()
        {
            try
            {
                var eventnames = unitOfWork.EventRepository.GetAll().Select(
                    p => new { DisplayText = p.EventName, Value = p.EventId });
                return Json(new JSONResult(eventnames, "Options"));
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