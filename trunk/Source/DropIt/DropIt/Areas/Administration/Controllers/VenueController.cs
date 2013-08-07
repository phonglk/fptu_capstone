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
using DropIt.Filters;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
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

        public ActionResult Index(int VenueStatus = 0)
        {
            ViewBag.VenueStatus = VenueStatus;

            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int VenueStatus = -1)
        {
            try
            {
                if (jtSorting.Trim().Equals(""))
                {
                    jtSorting = "VenueName ASC";
                }
                IEnumerable<DropIt.Models.Venue> records = null;
                if (VenueStatus == -1)
                {
                    records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                }
                else
                {
                    records = Repository.JTGetExp(e => e.Status == VenueStatus, jtStartIndex, jtPageSize, jtSorting);
                }
                var Records = records.Select(e => new
                {
                    VenueId = e.VenueId,
                    VenueName = e.VenueName,
                    Address = e.Address,
                     Province = new
                        {
                            e.Province.ProvinceId,
                            e.Province.ProvinceName
                        },
                    Description = e.Description,
                    Status = e.Status
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = (VenueStatus == -1) ? Repository.Count : Repository.Get(e =>e.Status == VenueStatus).Count()
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList( unitOfWork.ProvinceRepository.GetAll(),"ProvinceId", "ProvinceName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(Venue Venue)
        {
            String Error = "";
            try
            {
                Venue.Status = (int)Statuses.Venue.Approve;

                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Dữ liệu không hợp lệ";
                }

                var addedRecord = Repository.AddOrUpdate(Venue);
                unitOfWork.Save();

                TempData["Message"] = "Đã tạo mới thành công địa điểm " + Venue.VenueName;
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
                Result = "ERROR",
                Message = Error
            });
        }
        [HttpPost]
        public JsonResult Approve(int Id)
        {
            try
            {
                Venue delete = Repository.Get(e => e.VenueId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Venue.Approve;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.VenueId
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
        public ActionResult Edit(int Id)
        {
            Venue e = Repository.GetById(Id);
            VenueViewModel vvm = new VenueViewModel()
          {
              VenueId = e.VenueId,
              VenueName = e.VenueName,
              Address = e.Address,
              ProvinceId = e.ProvinceId,
              Description = e.Description,
              Status = e.Status,
              AllowEdit = e.Events.FirstOrDefault(t=> t.Status == (int)Statuses.Event.Trading) == null
          };
            ViewBag.ProvinceId = new SelectList(unitOfWork.ProvinceRepository.GetAll(), "ProvinceId", "ProvinceName", e.ProvinceId);
            return View(vvm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Venue Venue) 
        {
            Venue oldVenue = Repository.GetById(Venue.VenueId);
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }
                Venue.Status = oldVenue.Status;
                Repository.AddOrUpdate(Venue);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            };
        }
        [HttpPost]
        public JsonResult Disapprove(int Id)
        {
            try
            {
                Venue delete = Repository.Get(e => e.VenueId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Venue.Disapprove;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.VenueId
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
       
        public JsonResult Delete(int Id)
        {
            try
            {
                Venue delete = Repository.Get(e => e.VenueId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Venue.Delete;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    VenueId = delete.VenueId
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