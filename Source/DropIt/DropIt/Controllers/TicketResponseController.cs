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
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var res = this.unitOfWork.TicketRepository.Get(t => t.UserId == UserId).Select(t => t.EventId).Distinct().ToList();
            var RequestUser = this.unitOfWork.RequestRepository.Get(t => res.Contains(t.EventId));

            return View(RequestUser.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult List()
        {
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var request = this.unitOfWork.RequestRepository.Get(t => t.UserId == UserId).Select(t => t.EventId).Distinct().ToList();
            var respond = this.unitOfWork.TicketResponseRepository.Get(t => request.Contains(t.EventId));

            return View(respond.ToList());
        }
    }
}
