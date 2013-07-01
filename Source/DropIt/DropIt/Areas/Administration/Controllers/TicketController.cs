using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
    public class TicketController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;

        public TicketController()
        {
            Repository = unitOfWork.TicketRepository;
        }
        //
        // GET: /Administration/Ticket/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var ticketList = unitOfWork.TicketRepository.Get();
            return View(ticketList.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket==null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        
        public ActionResult Delete(int id)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            this.unitOfWork.TicketRepository.Delete(id);
            this.unitOfWork.TicketRepository.Save();
            return RedirectToAction("List");
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket==null)
            {
                HttpNotFound();
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName", ticket.EventId);
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                
                Ticket editTicket = new Ticket()
                                        {
                                            TicketId = ticket.TicketId,
                                            TranUserId = ticket.UserId,
                                            TranFullName = ticket.TranFullName,
                                            TranAddress = ticket.TranAddress,
                                            TranType = ticket.TranType,
                                            TranStatus = ticket.Status,
                                            EventId = ticket.EventId,
                                            UserId = ticket.UserId,
                                            SellPrice = ticket.SellPrice,
                                            ReceiveMoney = ticket.ReceiveMoney,
                                            Seat = ticket.Seat,
                                            Status = ticket.Status,
                                            Description = ticket.Description,
                                            CreatedDate = ticket.CreatedDate,
                                            TranCreatedDate = ticket.TranCreatedDate,
                                            TranModifiedDate = ticket.TranModifiedDate,
                                            TranDescription = ticket.TranDescription
                                        };
                this.unitOfWork.TicketRepository.AddOrUpdate(ticket);
                this.unitOfWork.TicketRepository.Save();
                return RedirectToAction("List");
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            return View(ticket);

        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
