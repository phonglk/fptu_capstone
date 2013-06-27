using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CheckOutController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;

        public CheckOutController()
        {
            Repository = unitOfWork.TicketRepository;
        }
        public ActionResult Checkout(int Id)
        {
            ViewBag.TicketId = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Ticket buyTicket)
        {
            Ticket getTicket = unitOfWork.TicketRepository.Get(u => u.TicketId == buyTicket.TicketId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Ticket checkout = new Ticket()
                                      {
                                          TicketId = getTicket.TicketId,
                                          TranUserId = getTicket.TranUserId,
                                          TranFullName = getTicket.TranFullName,
                                          TranAddress = getTicket.TranAddress,
                                          TranType = getTicket.TranType,
                                          TranStatus = (int)Statuses.BuyTicket.Paid,
                                          EventId = getTicket.EventId,
                                          UserId = getTicket.UserId,
                                          SellPrice = getTicket.SellPrice,
                                          ReceiveMoney = getTicket.ReceiveMoney,
                                          Seat = getTicket.Seat,
                                          Status = getTicket.Status,
                                          Description = getTicket.Description,
                                          CreatedDate = getTicket.CreatedDate,
                                          TranCreatedDate = getTicket.TranCreatedDate,
                                          TranModifiedDate = DateTime.Now,
                                          TranDescription = getTicket.TranDescription
                                      };
                this.unitOfWork.TicketRepository.AddOrUpdate(checkout);
                this.unitOfWork.Save();
                return RedirectToAction("HistoryBuy", "Transaction");
            }
            return View(buyTicket);
        }

    }
}
