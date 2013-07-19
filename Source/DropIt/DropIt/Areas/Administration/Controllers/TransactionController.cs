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
    public class TransactionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TransactionRepository Repository;

        public TransactionController()
        {
            Repository = unitOfWork.TransactionRepository;
        }
        //
        // GET: /Administration/Ticket/

        public ActionResult Index(int TicketStatus = 0)
        {
            ViewBag.TicketStatus = TicketStatus;
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int TicketStatus = -1)
        {
            try
            {
                IEnumerable<DropIt.Models.Ticket> records = null;
                if (TicketStatus == -1)
                {
                    records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                }
                else
                {
                    records = Repository.JTGetExp(e => e.Status == TicketStatus, jtStartIndex, jtPageSize, jtSorting);
                }
                var Records = records.Select(e => new
                {
                    TicketId = e.TicketId,
                    User = new {
                    e.UserId,
                    e.User.UserName
                    },
                    Event = new
                    {
                        e.EventId,
                        e.Event.EventName,
                        e.Event.HoldDate
                    },
                    SellPrice = e.SellPrice,
                    ReceiveMoney = e.ReceiveMoney,
                    Seat = e.Seat,
                    Description = e.Description,
                    Status = e.Status
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = (TicketStatus == -1) ? Repository.Count : Repository.Get(e => e.Status == TicketStatus).Count()
                });
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
                Ticket delete = Repository.Get(e => e.TicketId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Ticket.Ready;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.TicketId
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
                Ticket delete = Repository.Get(e => e.TicketId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Ticket.Pending;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = delete.TicketId
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
                Ticket delete = Repository.Get(e => e.TicketId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Ticket.Delete;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    VenueId = delete.TicketId
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
      
        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int Id)
        {
            Ticket e = Repository.GetById(Id);
            TicketViewModel tvm = new TicketViewModel()
            {
                TicketId = e.TicketId,
                EventId = e.EventId,
                UserId = e.UserId,
                SellPrice = (float) e.SellPrice,
                Seat = e.Seat,
                Description = e.Description,
                Status = e.Status
            };
            ViewBag.EventId = new SelectList(unitOfWork.EventRepository.GetAll(), "EventId", "EventName", e.EventId);
            ViewBag.VenueId = new SelectList(unitOfWork.VenueRepository.GetAll(), "VenueId", "VenueName", e.Event.VenueId);
            return View(tvm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Ticket Ticket)
        {
            Ticket oldTicket = Repository.GetById(Ticket.TicketId);
            if (oldTicket.Status == (int)Statuses.Ticket.OnTransaction)
            {
                return Json(new JSONResult()
                {
                    Result = "ERROR",
                    Message = "Vé này đang giao dịch nên không thể sửa thông tin"
                });
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }
                if (oldTicket.Status == 0) 
                {
                    Ticket.Status = 1;
                }
                else if (oldTicket.Status == 1) {
                    Ticket.Status = 3;
                }

                Repository.AddOrUpdate(Ticket);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            };
        }

    
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
