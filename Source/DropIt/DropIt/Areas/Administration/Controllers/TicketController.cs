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
                if (jtSorting.Trim().Equals(""))
                {
                    jtSorting = "Event.EventName ASC";
                }
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
                    SeriesNumber = e.SeriesNumber,
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
                Ticket ticket = Repository.GetById(Id);
                ticket.Status = (int)Statuses.Ticket.Ready;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
//                    EventId = delete.TicketId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
//                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Disapprove(int Id)
        {
            try
            {
                Ticket ticket = Repository.GetById(Id);
                ticket.Status = (int)Statuses.Ticket.Pending;

                Repository.AddOrUpdate(ticket);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
//                    EventId = delete.TicketId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
//                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            try
            {
                Ticket ticket = Repository.Get(e => e.TicketId == Id).FirstOrDefault();
                ticket.Status = (int)Statuses.Ticket.Delete;

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
                SeriesNumber = e.SeriesNumber,
                SellPrice = (float) e.SellPrice,
                Seat = e.Seat,
                Description = e.Description,
                Status = e.Status
            };
            ViewBag.EventId = new SelectList(unitOfWork.EventRepository.GetAvailable(), "EventId", "EventName", e.EventId);
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

                if (oldTicket.Status == (int)Statuses.Ticket.Pending) 
                {
                    oldTicket.Status = (int)Statuses.Ticket.Ready;
                }
                else if (oldTicket.Status == (int)Statuses.Ticket.Ready)
                {
                    oldTicket.Status = (int)Statuses.Ticket.UserApprove;
                }
                oldTicket.EventId = Ticket.EventId;
                oldTicket.Description = Ticket.Description;
                Repository.AddOrUpdate(oldTicket);
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
