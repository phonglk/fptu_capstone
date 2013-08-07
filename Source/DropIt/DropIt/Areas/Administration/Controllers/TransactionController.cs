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

        public ActionResult Index(int TranStatus = (int)Statuses.Transaction.Paid, int TranPaymentStatus = 0)
        {
            ViewBag.TranStatus = TranStatus;
            ViewBag.TranPaymentStatus = TranPaymentStatus;
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int TranStatus = -1, int TranPaymentStatus = -1)
        {
            try
            {
                if (jtSorting.Trim().Equals(""))
                {
                    jtSorting = "User.UserName ASC";
                }
                int TotalRecordCount = 0;
                IEnumerable<DropIt.Models.Ticket> records = Repository.Get();
                if (TranPaymentStatus == (int)Statuses.Payment.Transfered)
                {
                    records = records.Where(e => e.TranPaymentStatus == (int)Statuses.Payment.Transfered);
                }
                else
                {
                    if (TranStatus != -1)
                    {
                        records = records.Where(e => e.TranStatus == TranStatus);
                    }
                }
                TotalRecordCount = records.Count();
                records = Repository.JT(records, jtStartIndex, jtPageSize, jtSorting);
                var Records = records.Select(e => new
                {
                    TicketId = e.TicketId,
                    SellPrice = e.SellPrice,
                    User = new
                    {
                        e.UserId,
                        e.User.UserName,
                        e.User.BankAccount,
                        e.User.BankName
                    },
                    ReceiveMoney = e.ReceiveMoney,
                    SellUser = new {
                        e.UserId,
                        e.User.UserName
                    },
                    TranFullName = e.TranFullName,
                    TranType = e.TranType,
                    TranAddress = e.TranAddress,
                    TranShipDate = e.TranShipDate,
                    TranShipCode = e.TranShipCode,
                    TranPaymentStatus = e.TranPaymentStatus,
                    ShippingCost = e.ShippingCost,
                    TranUser = e.User1 == null ? null : new
                    {
                        e.TranUserId,
                        e.User1.UserName
                    },
                    TranDescription = e.TranDescription,
                    TranStatus = e.TranStatus,

                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = TotalRecordCount
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult Delivered(int Id, string TranShipCode)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranStatus = (int)Statuses.Transaction.Delivered;
                
                ticket.TranShipCode = TranShipCode;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = ticket.TicketId
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
        public JsonResult Paid(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranStatus = (int)Statuses.Transaction.Paid;
                
                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = ticket.TicketId
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
        public JsonResult Done(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranPaymentStatus = (int)Statuses.Payment.Done;
                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = ticket.TicketId
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
        public JsonResult Received(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranStatus = (int)Statuses.Transaction.Received;
                ticket.TranShipDate = DateTime.Now;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = ticket.TicketId
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
        public JsonResult Unpaid(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranStatus = (int)Statuses.Transaction.Unpaid;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    EventId = ticket.TicketId
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

        public JsonResult Canceled(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.TranStatus = (int)Statuses.Transaction.Canceled;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    VenueId = ticket.TicketId
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
                SellPrice = (float)e.SellPrice,
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
                else if (oldTicket.Status == 1)
                {
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
