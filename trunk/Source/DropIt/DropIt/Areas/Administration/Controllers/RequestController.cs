using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var requestList = unitOfWork.RequestRepository.Get();
            return View(requestList.ToList());
        }

        public ActionResult Details(int userid=0, int id = 0)
        {
            Request request = this.unitOfWork.RequestRepository.GetById(userid, id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        public ActionResult Delete(int userid, int id)
        {
            Request request = this.unitOfWork.RequestRepository.GetById(userid, id);
            if (request == null)
            {
                return HttpNotFound();
            }
            this.unitOfWork.RequestRepository.Delete(userid, id);
            this.unitOfWork.RequestRepository.Save();
            return RedirectToAction("List");
        }
        //public ActionResult Delete(int id)
        //{
        //    Request request = this.unitOfWork.RequestRepository.GetById(id);
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    this.unitOfWork.RequestRepository.Delete(id);
        //    this.unitOfWork.RequestRepository.Save();
        //    return RedirectToAction("List");
        //}

        ////
        //// GET: /Event/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Request request = this.unitOfWork.RequestRepository.GetById(id);
        //    if (request == null)
        //    {
        //        HttpNotFound();
        //    }
        //    ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName", ticket.EventId);
        //    return View(request);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Request request)
        //{
        //    Request getRequest = unitOfWork.RequestRepository.Get(u => u.RequestId == ticket.TicketId).FirstOrDefault();
        //    if (ModelState.IsValid)
        //    {

        //        Ticket editTicket = new Ticket()
        //        {
        //            TicketId = ticket.TicketId,  // co TicketId de tim kiem 
        //            TranUserId = getTicket.UserId,
        //            TranFullName = getTicket.TranFullName,
        //            TranAddress = getTicket.TranAddress,
        //            TranType = getTicket.TranType,
        //            TranStatus = getTicket.Status,
        //            EventId = ticket.EventId,
        //            UserId = getTicket.UserId,
        //            SellPrice = getTicket.SellPrice,
        //            ReceiveMoney = getTicket.ReceiveMoney,
        //            Seat = ticket.Seat,
        //            Status = ticket.Status,
        //            Description = ticket.Description,
        //            CreatedDate = getTicket.CreatedDate,
        //            TranCreatedDate = getTicket.TranCreatedDate,
        //            TranModifiedDate = getTicket.TranModifiedDate,
        //            TranDescription = getTicket.TranDescription
        //        };
        //        this.unitOfWork.TicketRepository.AddOrUpdate(editTicket);
        //        this.unitOfWork.TicketRepository.Save();
        //        return RedirectToAction("List");
        //    }
        //    ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
        //                                     ticket.EventId);
        //    return View(ticket);

        //}

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
