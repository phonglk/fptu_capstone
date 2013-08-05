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
using DropIt.Areas.Administration.ViewModels;

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
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int EventStatus = -1)
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
                    records = Repository.JTGetExp(e => e.Status == EventStatus, jtStartIndex, jtPageSize, jtSorting);
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
                    },
                    haveTicketTran = e.Status == (int)Statuses.Event.Trading
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
            ViewBag.CategoryId = unitOfWork.CategoryRepository.Get(c => c.Category2 == null).Select(r => new
            {
                r.CategoryId,
                r.CategoryName,
                Childs = r.Category1.Select(r2 => new
                {
                    r2.CategoryId,
                    r2.CategoryName,
                    ParentId = r2.Category2.CategoryId
                })
            });

            ViewBag.VenueId = new SelectList(unitOfWork.VenueRepository.Get(v => v.Status == (int)Statuses.Venue.Approve), "VenueId", "VenueName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(Event Event, HttpPostedFileBase EventImage)
        {
            String Error = "";
            if (Event.HoldDate < DateTime.Now)
            {
                return Json(new
                {
                    Result = "Lỗi",
                    Message = "Ngày diễn ra sự kiện phải sau ngày hiện tại!"
                });
            }
            if (EventImage != null)
            {
                if (EventImage.ContentLength <= 5000000 && EventImage.ContentType.IndexOf("image") > -1)
                {
                    Event.EventImage = Uploader.Upload(EventImage, this).ToString();
                }
                else
                {
                    return Json(new
                    {
                        Result = "Lỗi",
                        Message = "Hình sự kiện phải ở định dạng hình ảnh và bé hơn 5MB"
                    });
                }
            }

            try
            {
                Event.Status = (int)Statuses.Event.Approve;

                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Dữ liệu không hợp lệ";
                }

                var addedRecord = Repository.AddOrUpdate(Event);
                unitOfWork.Save();

                TempData["Message"] = "Đã tạo mới thành công sự kiện " + Event.EventName;
                return Json(new
                {
                    Result = "OK"
                });
            }
            catch (Exception e)
            {
                Error = "Có lỗi xảy ra";
            }

            return Json(new
            {
                Result = "Lỗi",
                Message = Error
            });
        }


        public ActionResult Edit(int Id)
        {
            Event e = Repository.GetById(Id);
            EventViewModel evm = new EventViewModel()
            {
                EventId = e.EventId,
                EventName = e.EventName,
                Artist = e.Artist,
                CategoryId = e.CategoryId,
                Description = e.Description,
                EventImage = e.EventImage,
                HoldDate = e.HoldDate,
                Status = e.Status,
                VenueId = e.VenueId,
                haveTicketTran = e.Status == (int)Statuses.Event.Trading
            };

            ViewBag.CategoryId = unitOfWork.CategoryRepository.Get(c => c.Category2 == null).Select(r => new
            {
                r.CategoryId,
                r.CategoryName,
                Childs = r.Category1.Select(r2 => new
                {
                    r2.CategoryId,
                    r2.CategoryName,
                    ParentId = r2.Category2.CategoryId
                })
            });

            ViewBag.VenueId = new SelectList(unitOfWork.VenueRepository.Get(v => v.Status == (int)Statuses.Venue.Approve), "VenueId", "VenueName");
            return View(evm);
        }



        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Event Event, HttpPostedFileBase EventImage)
        {
            Event oldEvent = Repository.GetById(Event.EventId);
            if (oldEvent.Status == (int)Statuses.Event.Trading)
            {
                return Json(new JSONResult()
                    {
                        Result = "Lỗi",
                        Message = "Sự kiện này đã có vé đã hoặc đang giao dịch nên không thể sửa thông tin"
                    });
            }

            if (Event.HoldDate < DateTime.Now)
            {
                return Json(new
                {
                    Result = "Lỗi",
                    Message = "Ngày diễn ra sự kiện phải sau ngày hiện tại!"
                });
            }
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
                        Result = "Lỗi",
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
                Event.Status = oldEvent.Status;
                Repository.AddOrUpdate(Event);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult getInfo(int EventId)
        {

            var Event = Repository.Get(e => e.EventId == EventId);

            if (Event != null)
            {
                return Json(new
                {
                    Result = "OK",
                    Records = Event.Select(e => new
                    {
                        e.Venue.VenueName,
                        e.Venue.VenueId,
                        e.Venue.Address,
                        e.Venue.Province.ProvinceId,
                        e.Venue.Province.ProvinceName,
                        e.CategoryId,
                        e.HoldDate
                    })
                });
            }
            else
            {
                return Json(new
                {
                    Result = "Lỗi",
                    Message = "Không tìm thấy sự kiện"
                });
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
                    Result = "Lỗi",
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
                    Result = "Lỗi",
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
                    Result = "Lỗi",
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