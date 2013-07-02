using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using DropIt.Models;
using DropIt.DAL;
using DropIt.Common;
using WebMatrix.WebData;
using DropIt.ViewModels;

namespace DropIt.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/

        private UnitOfWork unitOfWork = new UnitOfWork();
        private RequestRepository Repository;

        public RequestController()
        {
            Repository = unitOfWork.RequestRepository;
        }

        public ActionResult Index()
        {
            var CurUserId = WebSecurity.GetUserId(User.Identity.Name);
            var rqt = this.unitOfWork.RequestRepository.Get(u => u.UserId == CurUserId);

            return View(rqt.ToList());
        }

        public JsonResult Close(Request Request, int UserId, int EventId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                Repository.AddOrUpdate(Request);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public ActionResult Details(int EventId)
        {
            var CurUserId = WebSecurity.GetUserId(User.Identity.Name);
            Request rqt = this.unitOfWork.RequestRepository.Get(u=>u.UserId == CurUserId && u.EventId == EventId).FirstOrDefault();
            if (rqt == null)
            {
                return HttpNotFound();
            }
            return View(rqt);
        }

        public ActionResult CloseRequest()
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            var close = this.unitOfWork.RequestRepository.Get(x => x.UserId == UserId).ToList();
            return View(close.ToList());
        }

        [HttpPost]
        public JsonResult CloseRequest(int EventId = 0)
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            Request open = this.unitOfWork.RequestRepository.Get(r => r.UserId == UserId && r.EventId == EventId).FirstOrDefault();
            this.unitOfWork.RequestRepository.Delete(open);
            return Json(open);
        }

        //
        // POST: /Request/Edit/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(RequestViewModels request)
        //{

        //}
    }
}