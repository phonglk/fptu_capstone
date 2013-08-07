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
using DropIt.Filters;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class TicketResponseController : Controller
    {
        //
        // GET: /ResponseTicket/
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketResponseRepository Repository;

        public TicketResponseController()
        {
            Repository = unitOfWork.TicketResponseRepository;
        }
        public ActionResult Index()
        {
            var CurUserId = WebSecurity.GetUserId(User.Identity.Name);
            var res = this.unitOfWork.TicketResponseRepository.Get(u => u.UserId == CurUserId);

            return View(res.ToList());
        }

    }
}
