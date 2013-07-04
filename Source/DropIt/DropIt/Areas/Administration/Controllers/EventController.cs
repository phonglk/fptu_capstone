﻿using System;
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

        public ActionResult Index(int EventStatus = 0)
        {
            ViewBag.EventStatus = EventStatus;
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null,int EventStatus = -1)
        {
            try
            {
                IEnumerable<DropIt.Models.Event> records = null;

                if (EventStatus == -1)
                {
                    records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);
                }
                else
                {
                    records = Repository.JTGetExp(e=> e.Status == EventStatus,jtStartIndex, jtPageSize, jtSorting);
                }
                var Records = records.Select(e => new
                {
                    EventId = e.EventId,
                    EventName = e.EventName,
                    EventImage = e.EventImage,
                    Artist = e.Artist,
                    HoldDate = e.HoldDate,
                    Description = e.Description,
                    Status = e.Status,
                    Category = new
                    {
                        e.CategoryId,
                        e.Category.CategoryName
                    },
                    Venue = new
                    {
                        e.VenueId,
                        e.Venue.VenueName,
                        e.Venue.Address,
                        Province = new
                        {
                            e.Venue.Province.ProvinceId,
                            e.Venue.Province.ProvinceName
                        }
                    }
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = (EventStatus == -1) ? Repository.Count : Repository.Get(e => e.Status == EventStatus).Count()
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public ActionResult Create()
        {
            return View();
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

        //public JsonResult Delete(int EventId)
        //{
        //    try
        //    {
        //        Repository.Delete(EventId);
        //        unitOfWork.Save();

        //        return Json(new JSONResult());
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new JSONResult(e));
        //    }

        //}
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

        [HttpPost]
        public JsonResult Approve(int Id)
        {
            try
            {
                Event delete = Repository.Get(e => e.EventId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Event.Approve;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.EventId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Disapprove(int Id)
        {
            try
            {
                Event delete = Repository.Get(e => e.EventId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Event.Disapprove;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.EventId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            try
            {
                Event delete = Repository.Get(e => e.EventId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Event.Delete;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.EventId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
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