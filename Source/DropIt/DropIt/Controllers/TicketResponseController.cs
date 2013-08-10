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
        private RequestRepository RequestRepo;

        public TicketResponseController()
        {
            Repository = unitOfWork.TicketResponseRepository;
            RequestRepo = unitOfWork.RequestRepository;
        }
        public ActionResult Index()
        {
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            var MyTickets = this.unitOfWork.TicketRepository.Get(t => t.Status == (int)Statuses.Ticket.Ready && t.UserId == UserId);
            var TicketIds = MyTickets.Select(t => t.TicketId);
            var EventIds = MyTickets.Select(t => t.EventId);
            var Requests = this.unitOfWork.RequestRepository.Get(r=> EventIds.Contains( r.EventId) && r.UserId != UserId);
            Requests = Requests.SkipWhile(r => MyTickets.Where(t => t.EventId == r.EventId).Count() <= r.TicketResponses.Where(tr => tr.Ticket.UserId == UserId).Count());
            return View(Requests.ToList());
        }

        public ActionResult Create(int UserId = -1,int EventId = -1)
        {
            Session["Role"] = "Sell";
            Request req = RequestRepo.GetById(UserId, EventId);
            int CurUID = WebSecurity.GetUserId(User.Identity.Name);
            IEnumerable<Ticket> Tickets = null;
            ViewBag.IsExist = true;
            if (req == null)
            {
                ViewBag.IsExist = false;
            }
            else
            {
                ViewBag.Event = req.Event;
                ViewBag.User = req.User;
                ViewBag.Request = req;
                Tickets = unitOfWork.TicketRepository.Get(t=>t.Status == (int)Statuses.Ticket.Ready && t.EventId == EventId && t.UserId == CurUID).SkipWhile(t=>Repository.Get(tr => tr.TicketId == t.TicketId).Count() > 0);
                ViewBag.Tickets = Tickets.ToList();
            }
            
            var  responses = new List<ResponseSubmit>();
            foreach (Ticket Ticket in Tickets)
            {
                responses.Add(new ResponseSubmit()
                {
                    TicketId = Ticket.TicketId,
                    IsResponse = false,
                    Description = null
                });
            }
            var vm = new CreateResponses()
            {
                EventId = EventId,
                UserId = UserId,
                responses = responses
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Response(CreateResponses data)
        {
            Request req = RequestRepo.GetById(data.UserId, data.EventId);
            int CurUID = WebSecurity.GetUserId(User.Identity.Name);
            if (req == null)
            {
                Session["Message"] = "Không tìm thấy request tương ứng";
                Session["MessageType"] = "error";
                return RedirectToAction("Index");
            }
            if (data.responses.Count == 0)
            {
                Session["Message"] = "Bạn đã không có phản hồi nào";
                return RedirectToAction("Index");
            }
            else
            {
                int ResponseNum = 0;
                foreach( var response in data.responses){
                    if (response.IsResponse)
                    {
                        if (req.Event.Tickets.Where(t => t.TicketId == response.TicketId && t.UserId == CurUID).Count() == 0)
                        {
                            Session["Message"] = "Vé bạn phản hồi không phải vé trong event của yêu cầu hoặc không phải vé của bạn!";
                            Session["MessageType"] = "error";
                            return RedirectToAction("Index");
                        }
                        TicketResponse ticketResponse = new TicketResponse(){
                            EventId = data.EventId,
                            Description = response.Description,
                            TicketId = response.TicketId,
                            UserId = data.UserId
                        };
                        Repository.Add(ticketResponse);
                        ResponseNum++;
                    }
                }
                if (ResponseNum == 0)
                {
                    Session["Message"] = "Bạn không có phản hồi nào";
                }
                else
                {
                    Session["Message"] = "Đã tạo phản hồi thành công! ";
                    Session["MessageType"] = "success";
                    Repository.Save();
                }
            }
            
            return  RedirectToAction("Index");
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
