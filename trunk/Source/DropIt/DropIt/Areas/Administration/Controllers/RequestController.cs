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
using WebMatrix.WebData;

namespace DropIt.Areas.Administration.Controllers
{
    
    public class RequestController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private RequestRepository Repository;

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
                    User = new
                    {
                        e.UserId,
                        e.User.UserName
                    },
                    Event = new
                    {
                        e.EventId,
                        e.Event.EventName
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

        [HttpPost]
        public JsonResult Close(int UserId, int EventId)
        {
            try
            {
                Request delete = Repository.GetById(UserId, EventId);

                delete.Status = (int)Statuses.Request.Close;

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
                    EventId = EventId,
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
