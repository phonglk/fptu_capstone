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

        //public ActionResult Index()
        //{
        //    int id = WebSecurity.GetUserId(User.Identity.Name);
        //    Request request = this.unitOfWork.RequestRepository.GetById(id);
        //    RequestViewModels newRequest = new RequestViewModels
        //    {
        //        UserId = request.UserId,
        //        EventId = request.EventId,
        //        Status = request.Status,
        //        Description = request.Description
        //    };
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(newRequest);
        //}

        public ActionResult Index()
        {
            var requests = this.unitOfWork.RequestRepository.GetAll();
            return View(requests.ToList());
        }

        public ActionResult Close(int id = 0)
        {
            return View();
        }

        public ActionResult Details(int UserId, int EventId)
        {
            Request rqt = this.unitOfWork.RequestRepository.GetById(UserId, EventId);
            if (rqt == null)
            {
                return HttpNotFound();
            }
            return View(rqt);
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