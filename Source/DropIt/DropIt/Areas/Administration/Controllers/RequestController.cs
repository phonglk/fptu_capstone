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
    
    public class RequestController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private GenericRepository<Request> Repository;

        public RequestController()
        {
            Repository = unitOfWork.RequestRepository;
        }
        //
        // GET: /Administration/Request/

        public ActionResult Index(int RequestStatus = 0)
        {
            ViewBag.RequestStatus = RequestStatus;
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int RequestStatus = -1)
        {
            try
            {
                IEnumerable<DropIt.Models.Request> records = null;

                if (RequestStatus == -1)
                {
                    records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);
                }
                else
                {
                    records = Repository.JTGetExp(e => e.Status == RequestStatus, jtStartIndex, jtPageSize, jtSorting);
                }


                var Records = records.Select(e => new
                {
                    ReportId = new {
                        e.EventId,
                        e.UserId
                    },
                    Status = e.Status,
                    Description = e.Description                    
                });

                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = (RequestStatus == -1) ? Repository.Count : Repository.Get(e => e.Status == RequestStatus).Count()
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                Category delete = Repository.Get(e => e.RequestId == Id).FirstOrDefault();
                if (delete.Events.Where(p => p.Status != (int)Statuses.Event.Delete || p.Status != (int)Statuses.Event.Outdate).Count() == 0)
                {
                    delete.Status = (int)Statuses.Category.Delete;
                }

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    CategoryId = delete.CategoryId
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
