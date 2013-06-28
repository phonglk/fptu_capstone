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


    }
}
