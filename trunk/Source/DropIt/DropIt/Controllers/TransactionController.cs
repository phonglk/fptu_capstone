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

        public ActionResult HistoryBuy()
        {
            var status = Request["status"];
            if (status == null) status = "1";
            int CurrentStatus = Int32.Parse(status);

            //ViewBag.status = new SelectList(StatusList);
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var historyTransaction = this.unitOfWork.TicketRepository.Get(u => u.TranUserId == UserId && u.TranStatus == CurrentStatus);

            ViewBag.CurrentStatus = CurrentStatus;
            return View(historyTransaction.ToList());
        }

        public ActionResult HistorySell()
        {
            var status = Request["status"];
            if (status == null) status = "1";
            int CurrentStatus = Int32.Parse(status);

            //ViewBag.status = new SelectList(StatusList);
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var historyTransaction = this.unitOfWork.TicketRepository.Get(u => u.UserId == UserId && u.TranStatus == CurrentStatus);

            ViewBag.CurrentStatus = CurrentStatus;
            return View(historyTransaction.ToList());
        }

        public ActionResult Receive(int Id)
        {
            var tran = Repository.GetById(Id);
            if (tran == null)
            {
                Session["Message"] = "Không tồn tại vé này";
                return RedirectToAction("HistoryBuy",new {status=2});
            }
            else if (tran.TranStatus != (int)Statuses.Transaction.Delivered)
            {
                Session["Message"] = "Giao dịch bạn yêu cầu không hợp lệ";
                return RedirectToAction("HistoryBuy", new { status = 2 });
            }
            else
            {
                tran.TranStatus = (int)Statuses.Transaction.Received;
                Repository.AddOrUpdate(tran);
                Repository.Save();
                Session["Message"] = "Vé của sự kiện <strong>"+tran.Event.EventName+"</strong> đã được chuyển sang đã nhận thành công!";
                return RedirectToAction("HistoryBuy", new { status = 3 });
            }
        }

        [HttpPost]
        public JsonResult Count(int id)
        {
            int status = id;
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            int count = 0;

            if (Request["extra"] != null && Request["extra"] == "ontransaction")
            {
                count = Repository.Get(r => r.TranUserId == UserId && (r.TranStatus == (int)Statuses.Transaction.Paid || r.TranStatus == (int)Statuses.Transaction.Delivered)).Count();
                return Json(new
                {
                    Result = "OK",
                    Count = count
                });
            }

            if (id == -1)
            {
                count = Repository.Get(r => r.TranUserId == UserId && r.TranStatus != null).Count();
            }
            else
            {
                count = Repository.Get(r => r.TranUserId == UserId && r.TranStatus == status).Count();
            }

            return Json(new
            {
                Result = "OK",
                Count = count
            });
        }

    }
}
