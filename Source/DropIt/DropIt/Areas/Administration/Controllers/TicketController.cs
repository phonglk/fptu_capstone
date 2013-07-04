using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using WebMatrix.WebData;

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
            var status = Request["status"];
            if (status == null) status = "0";
            int CurrentStatus = Int32.Parse(status);
            ViewBag.CurrentStatus = CurrentStatus;
            var ticketList = unitOfWork.TicketRepository.Get(u => u.Status == CurrentStatus);
            return View(ticketList.ToList());
        }

        [HttpPost]

        public JsonResult Count(int id)
        {
            int status = id;

            int count = 0;

            if (Request["extra"] != null && Request["extra"] == "ontransaction")
            {
                count = Repository.Get(r => (r.Status == (int)Statuses.Ticket.Ready || r.Status == (int)Statuses.Ticket.Pending)).Count();
                return Json(new
                {
                    Result = "OK",
                    Count = count
                });
            }

            if (id == -1)
            {
                count = Repository.Get(r => r.Status != null).Count();
            }
            else
            {
                count = Repository.Get(r => r.Status == status).Count();
            }

            return Json(new
            {
                Result = "OK",
                Count = count
            });
        }

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);

            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }


        public ActionResult Delete(int id)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            int sttToRedirect = 0;
            if (ticket == null)
            {
                HttpNotFound();
            }           
                ticket.Status = (int)Statuses.Ticket.Delete;
                sttToRedirect = (int)Statuses.Ticket.Pending;           

            Ticket change = new Ticket()
            {
                TicketId = ticket.TicketId,  // co TicketId de tim kiem 
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
                AdminModifiedDate = DateTime.Now,
                Description = ticket.Description,
                CreatedDate = ticket.CreatedDate,
                TranCreatedDate = ticket.TranCreatedDate,
                TranModifiedDate = ticket.TranModifiedDate,
                TranDescription = ticket.TranDescription
            };
            this.unitOfWork.TicketRepository.AddOrUpdate(change);
            this.unitOfWork.TicketRepository.Save();
            return RedirectToAction("List", new { status = sttToRedirect });
        }


        // GET: Change status

        public ActionResult ChangeStatus(int id)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            int sttToRedirect = 0;
            if (ticket == null)
            {
                HttpNotFound();
            }
            else if (ticket.Status == 0)
            {
                ticket.Status = (int)Statuses.Ticket.Ready;
                sttToRedirect = (int)Statuses.Ticket.Pending;
            }
            else if (ticket.Status == 1)
            {
                ticket.Status = (int)Statuses.Ticket.Pending;
                sttToRedirect = (int)Statuses.Ticket.Ready;
            }

            Ticket change = new Ticket()
                                {
                                    TicketId = ticket.TicketId,  // co TicketId de tim kiem 
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
                                    AdminModifiedDate = DateTime.Now,
                                    Description = ticket.Description,
                                    CreatedDate = ticket.CreatedDate,
                                    TranCreatedDate = ticket.TranCreatedDate,
                                    TranModifiedDate = ticket.TranModifiedDate,
                                    TranDescription = ticket.TranDescription
                                };
            this.unitOfWork.TicketRepository.AddOrUpdate(change);
            this.unitOfWork.TicketRepository.Save();
            return RedirectToAction("List", new { status = sttToRedirect });
        }
        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket == null)
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
            Ticket getTicket = unitOfWork.TicketRepository.Get(u => u.TicketId == ticket.TicketId).FirstOrDefault();
            if (ModelState.IsValid)
            {

                Ticket editTicket = new Ticket()
                                        {
                                            TicketId = ticket.TicketId,  // co TicketId de tim kiem 
                                            TranUserId = getTicket.UserId,
                                            TranFullName = getTicket.TranFullName,
                                            TranAddress = getTicket.TranAddress,
                                            TranType = getTicket.TranType,
                                            TranStatus = getTicket.Status,
                                            EventId = ticket.EventId,  // sua Event lai
                                            UserId = getTicket.UserId,
                                            SellPrice = getTicket.SellPrice,
                                            ReceiveMoney = getTicket.ReceiveMoney,
                                            Seat = ticket.Seat,   // sua thong tin ghe ngoi
                                            Status = (int)Statuses.Ticket.UserApprove,  // sua trang thai chuyen ve userapprove gui den user 
                                            AdminModifiedDate = DateTime.Now,  // cap nhat ngay sua
                                            Description = ticket.Description,  // sua lai phan ghi chu
                                            CreatedDate = getTicket.CreatedDate,
                                            TranCreatedDate = getTicket.TranCreatedDate,
                                            TranModifiedDate = getTicket.TranModifiedDate,
                                            TranDescription = getTicket.TranDescription
                                        };
                this.unitOfWork.TicketRepository.AddOrUpdate(editTicket);
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
