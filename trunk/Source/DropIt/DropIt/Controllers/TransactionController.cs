using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TransactionController : Controller
    {
        //
        // GET: /Transaction/
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;

        public TransactionController()
        {
            Repository = unitOfWork.TicketRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HistoryBuy(int status)
        {
            
            
            ViewBag.status = new SelectList(StatusList);
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var historyTransaction = this.unitOfWork.TicketRepository.Get(u => u.TranUserId == UserId && u.TranStatus == (int)Statuses.BuyTicket.Paid);
            return View(historyTransaction.ToList());
        }

    }
}
