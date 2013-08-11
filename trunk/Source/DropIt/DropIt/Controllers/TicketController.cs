using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class TicketController : Controller
    {
        double service = Double.Parse(Settings.get("ServiceFee"));
        double shippingcost = Double.Parse(Settings.get("ShippingCost"));        
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;
        //
        // GET: /Ticket/

        public TicketController()
        {
            Repository = unitOfWork.TicketRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var date = DateTime.Now;
            int noPost = int.Parse(Settings.get("TicketPostPerDay"));
            var yesterday = DateTime.Now.AddDays(-1);
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            Boolean checkSellable = unitOfWork.UserRepository.GetById(UserId).Sellable;     
            int noTicket = this.unitOfWork.TicketRepository.Get().Where(t => t.CreatedDate <= date && t.CreatedDate > yesterday && t.UserId==UserId).Count();
            ViewBag.NoPostTicket = noTicket;
            ViewBag.noSetting = noPost;
            ViewBag.Sellable = checkSellable;
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.GetAvailable(), "EventId", "EventName");
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.GetAvailable(), "VenueId", "VenueName");
            ViewBag.CategoryId = unitOfWork.CategoryRepository.GetAvailable().Where(c => c.Category2 == null).Select(r => new
            {
                r.CategoryId,
                r.CategoryName,
                Childs = r.Category1.Select(r2 => new
                {
                    r2.CategoryId,
                    r2.CategoryName,
                    ParentId = r2.Category2.CategoryId
                })
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostTicket ticket)
        {
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.GetAvailable(), "EventId", "EventName");
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.GetAvailable(), "VenueId", "VenueName");
            ViewBag.CategoryId = unitOfWork.CategoryRepository.Get(c => c.Category2 == null).Where(c => c.Status != 2).Select(r => new
            {
                r.CategoryId,
                r.CategoryName,
                Childs = r.Category1.Select(r2 => new
                {
                    r2.CategoryId,
                    r2.CategoryName,
                    ParentId = r2.Category2.CategoryId
                })
            });

            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            double receivemoney = (int) (ticket.SellPrice*(1 - service));
            if (ModelState.IsValid)
            {
                if (Request.Form["CreateEvent"] != null) // create new event
                {
                    if (ticket.HoldDate <= DateTime.Now)
                    {
                        Session["Message"] = "Ngày diễn ra sự kiện không được nhỏ hơn hiện tại";
                        Session["MessageType"] = "error";
                        return View();
                    }
                    if (Request.Form["CreateVenue"] != null) // create new venue
                    {
                        // add new venue 
                        Venue venue = new Venue()
                        {
                            VenueName = ticket.VenueName,
                            Address = ticket.Address,
                            ProvinceId = (int)ticket.ProvinceId,
                            Status = (int)Statuses.Venue.Disapprove
                        };
                        this.unitOfWork.VenueRepository.AddOrUpdate(venue);
                        this.unitOfWork.Save();

                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = (int)Statuses.Event.Disapprove,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = venue.VenueId        
                        };

                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new ticket
                        Ticket NewTicket = new Ticket()
                        {
                            EventId = newEvent.EventId,
                            SeriesNumber = ticket.SeriesNumber,
                            SellPrice = ticket.SellPrice,
                            ReceiveMoney = (System.Math.Floor(receivemoney/500))*500,
                            Seat = ticket.Seat,
                            Description = ticket.Description,
                            Status = (int)Statuses.Ticket.Pending,
                            UserId = ticket.UserId
                        };
                        this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                        this.unitOfWork.Save();
                        
                    }

                    else //if(ticket.EventId!=null)
                    {
                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = (int)Statuses.Event.Disapprove,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = (int)ticket.CategoryId,
                            VenueId = (int)ticket.VenueId
                        };
                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new ticket with EventName was created in db
                        Ticket NewTicket = new Ticket()
                        {
                            EventId = newEvent.EventId,
                            SeriesNumber = ticket.SeriesNumber,
                            SellPrice = ticket.SellPrice,
                            ReceiveMoney = (System.Math.Floor(receivemoney / 500)) * 500,
                            Seat = ticket.Seat,
                            Description = ticket.Description,
                            Status = (int)Statuses.Ticket.Pending,
                            UserId = ticket.UserId
                        };
                        this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                        this.unitOfWork.Save();
                    }
                }
                else
                {
                    Ticket NewTicket = new Ticket()
                    {
                        EventId = (int)ticket.EventId,
                        SeriesNumber = ticket.SeriesNumber,
                        SellPrice = ticket.SellPrice,
                        ReceiveMoney = (System.Math.Floor(receivemoney / 500)) * 500,
                        Seat = ticket.Seat,
                        Description = ticket.Description,
                        Status = (int)Statuses.Ticket.Ready,
                        UserId = ticket.UserId
                    };
                    this.unitOfWork.TicketRepository.AddOrUpdate(NewTicket);
                    this.unitOfWork.Save();
                }

                Session["Message"] = "Bạn đã đăng vé thành công !";
                Session["MessageType"] = "success";
                return RedirectToAction("Index", "Home");
            }
            
            return View(ticket);
        }
        

        //Get: /
        public ActionResult Buy(int Id)
        {
            ViewBag.TicketId = Id;
            Ticket getTicket = unitOfWork.TicketRepository.GetById(Id);
            User CurrentUser = unitOfWork.UserRepository.GetById(WebSecurity.CurrentUserId);            
            BuyTicket buyTicket = new BuyTicket()
                                      {
                                          TicketId = getTicket.TicketId,
                                          UserId = getTicket.UserId,
                                          SeriesNumber = getTicket.SeriesNumber,
                                          SellPrice = getTicket.SellPrice,
                                          ReceiveMoney = getTicket.ReceiveMoney,
                                          ShippingCost = shippingcost,     // tien ship cua minh lay
                                          Seat = getTicket.Seat,
                                          Description = getTicket.Description,
                                          EventName = getTicket.Event.EventName,
                                          HoldDate = getTicket.Event.HoldDate,
                                          VenueName = getTicket.Event.Venue.VenueName
                                      };
            ViewBag.TranFullName = CurrentUser.FullName;
            ViewBag.TranAddress = CurrentUser.Address;
            return View(buyTicket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(BuyTicket buyTicket)
        {
            if (buyTicket.TranType==1)
            {
                buyTicket.TranType = (int)Statuses.TranType.HoldPayment;
            }
            else
            {
                buyTicket.TranType = (int) Statuses.TranType.InstantPayment;
            }
            buyTicket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            Ticket ticket = unitOfWork.TicketRepository.Get(u => u.TicketId == buyTicket.TicketId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Ticket newticket = new Ticket()
                {
                    TicketId = buyTicket.TicketId,
                    TranUserId = buyTicket.UserId,
                    TranFullName = buyTicket.TranFullName,
                    TranAddress = buyTicket.TranAddress,
                    TranType = buyTicket.TranType,
//                    TranStatus = (int)Statuses.Transaction.Unpaid,
                    EventId = ticket.EventId,
                    UserId = ticket.UserId,
                    SeriesNumber = ticket.SeriesNumber,
                    SellPrice = ticket.SellPrice,
                    ReceiveMoney = ticket.ReceiveMoney,
                    ShippingCost = shippingcost,  // tien ship minh thu                    
                    Seat = ticket.Seat,
                    Status = ticket.Status,
                    AdminModifiedDate = ticket.AdminModifiedDate,
                    Description = ticket.Description,
                    CreatedDate = ticket.CreatedDate,
                    TranCreatedDate = DateTime.Now,
                    TranModifiedDate = DateTime.Now,
                    TranDescription = buyTicket.TranDescription
                };
                this.unitOfWork.TicketRepository.AddOrUpdate(newticket);
                this.unitOfWork.Save();
                return RedirectToAction("Checkout", "CheckOut",new {Id = newticket.TicketId});
            }
            return View(buyTicket);
        }

        //Get: /ResquestTicket
        [ActionName("Request")]
        public ActionResult RequestTicket(int EventId = 0)
        {
            var UserId = WebSecurity.GetUserId(User.Identity.Name);

            if (EventId != 0 && this.unitOfWork.RequestRepository.Get(r => r.EventId == EventId && r.UserId == UserId).Count() != 0)
            {
                Session["Message"] = "Vé này bạn đã đăng rao mua, xin chờ người phản hồi!";
                return RedirectToAction("Details", "Event", new { Id = EventId });
            }

            var date = DateTime.Now;
            int noRe = int.Parse(Settings.get("TicketRequestPerDay"));
            var yesterday = DateTime.Now.AddDays(-1);
            
            var request = this.unitOfWork.RequestRepository.Get().Where(t => t.CreatedDate != null);
            int noRequest = request.Where(t => t.CreatedDate <= date && t.CreatedDate > yesterday && t.UserId == UserId).Count();
            ViewBag.NoRequest = noRequest;
            ViewBag.NoRe = noRe;
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.GetRequestAvailable(UserId), "EventId", "EventName");
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName");
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.GetAvailable(), "VenueId", "VenueName");
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.GetAvailable(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ActionName("Request")]
        [ValidateAntiForgeryToken]
        public ActionResult RequestTicket(RequestTicket ticket)
        {
            ticket.UserId = WebSecurity.GetUserId(User.Identity.Name);
            if (ModelState.IsValid)
            {
                if (Request.Form["CreateEvent"] != null)
                {
                    if (Request.Form["CreateVenue"] != null)
                    {
                        //add new venue
                        Venue newVenue = new Venue()
                        {
                            VenueName = ticket.VenueName,
                            Address = ticket.Address,
                            ProvinceId = (int)ticket.ProvinceId,
                            Status = 1
                        };
                        this.unitOfWork.VenueRepository.AddOrUpdate(newVenue);
                        this.unitOfWork.Save();

                        // add new event
                        Event newEvent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = 0,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = newVenue.VenueId
                        };
                        this.unitOfWork.EventRepository.AddOrUpdate(newEvent);
                        this.unitOfWork.Save();

                        // add new request
                        Request newrequest = new Request()
                        {
                            UserId = ticket.UserId,
                            EventId = newEvent.EventId,
                            Status = (int)Statuses.Request.Open,
                            CreatedDate = DateTime.Now,
                            Description = ticket.Description
                        };
                        this.unitOfWork.RequestRepository.AddOrUpdate(newrequest);
                        this.unitOfWork.Save();
                    }
                    else
                    {
                        // add new Event
                        Event newevent = new Event()
                        {
                            EventName = ticket.EventName,
                            Status = (int)Statuses.Request.Open,
                            HoldDate = (DateTime)ticket.HoldDate,
                            CategoryId = ticket.CategoryId,
                            VenueId = (int)ticket.VenueId
                        };
                        this.unitOfWork.EventRepository.AddOrUpdate(newevent);
                        this.unitOfWork.Save();

                        // add new Request
                        Request newRequest = new Request()
                        {
                            UserId = ticket.UserId,
                            EventId = newevent.EventId,
                            CreatedDate = DateTime.Now,
                            Description = ticket.Description,
                            Status = (int)Statuses.Request.Open,
                        };
                    }
                }
                else
                {
                    // add to request

                    if (this.unitOfWork.RequestRepository.Get(r => r.EventId == ticket.EventId && r.UserId == ticket.UserId).Count() != 0)
                    {
                        Session["Message"] = "Vé này bạn đã đăng rao mua, xin chờ người phản hồi!";
                        return RedirectToAction("Details", "Event", new { Id = ticket.EventId });
                    }

                    Request request = new Request()
                    {
                        UserId = ticket.UserId,
                        EventId = (int)ticket.EventId,
                        Status = (int)Statuses.Request.Open,
                        CreatedDate = DateTime.Now,
                        Description = ticket.Description
                    };
                    this.unitOfWork.RequestRepository.AddOrUpdate(request);
                    this.unitOfWork.Save();
                }

                Session["Message"] = "Bạn đã rao vé thành công, xin hãy chờ người phản hồi vé !";
                Session["MessageType"] = "success";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                             ticket.ProvinceId);
            ViewBag.CategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", ticket.CategoryId);
            ViewBag.VenueId = new SelectList(this.unitOfWork.VenueRepository.Get(), "VenueId", "VenueName", ticket.VenueId);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Count()
        {
            try
            {
                return Json(new
                {
                    Result = "OK",
                    Count = Repository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Count = 0
                });
            }
        }

        public ActionResult Approve(int id = 0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket==null)
            {
                HttpNotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(Ticket ticket)
        {
            Ticket getTicket = this.unitOfWork.TicketRepository.Get(u => u.TicketId == ticket.TicketId).FirstOrDefault();
            //Ticket getTicket2 = this.unitOfWork.TicketRepository.GetById(ticket.TicketId);  tuong tu nhu cau lenh o tren 
            if (ModelState.IsValid)
            {
                Ticket newTicket = new Ticket()
                                       {
                                           TicketId = getTicket.TicketId,
                                           TranUserId = getTicket.UserId,
                                           TranFullName = getTicket.TranFullName,
                                           TranAddress = getTicket.TranAddress,
                                           TranType = getTicket.TranType,
                                           TranStatus = getTicket.TranStatus,
                                           EventId = getTicket.EventId,  
                                           UserId = getTicket.UserId,
                                           SeriesNumber = getTicket.SeriesNumber,
                                           SellPrice = getTicket.SellPrice,
                                           ReceiveMoney = getTicket.ReceiveMoney,
                                           Seat = getTicket.Seat,    
                                           Status = (int)Statuses.Ticket.Ready,  // chuyen ve trang thai Ready
                                           AdminModifiedDate = getTicket.AdminModifiedDate,
                                           Description = getTicket.Description,   
                                           CreatedDate = getTicket.CreatedDate,
                                           TranCreatedDate = getTicket.TranCreatedDate,
                                           TranModifiedDate = getTicket.TranModifiedDate,
                                           TranDescription = getTicket.TranDescription
                                       };
                this.unitOfWork.TicketRepository.AddOrUpdate(newTicket);
                this.unitOfWork.TicketRepository.Save();
                return RedirectToAction("Manage");
            }
            return View(ticket);
        }

        //Get: edit info ticket
        // user co the edit lai thong tin ve va dang ve lai
        public ActionResult Edit(int id=0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket==null)
            {
                HttpNotFound();
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.GetAvailable(), "EventId", "EventName",
                                             ticket.EventId);
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Ticket ticket)
        {
            Ticket getTicket = this.unitOfWork.TicketRepository.GetById(ticket.TicketId);
            double receivemoney = (int)(ticket.SellPrice * (1 - service));
            if (ModelState.IsValid)
            {
                Ticket newTicket = new Ticket()
                                       {
                                           TicketId = getTicket.TicketId,
                                           TranUserId = getTicket.UserId,
                                           TranFullName = getTicket.TranFullName,
                                           TranAddress = getTicket.TranAddress,
                                           TranType = getTicket.TranType,
                                           TranStatus = getTicket.TranStatus,
                                           EventId = ticket.EventId,  // thay doi
                                           UserId = getTicket.UserId,
                                           SeriesNumber = ticket.SeriesNumber, // thay doi
                                           SellPrice = ticket.SellPrice,  // thay doi
                                           ReceiveMoney = (System.Math.Floor(receivemoney / 500)) * 500,  // thay doi
                                           Seat = ticket.Seat,  // thay doi
                                           Status = (int)Statuses.Ticket.Ready,  // dua ve trang thai ready
                                           AdminModifiedDate = getTicket.AdminModifiedDate,
                                           Description = ticket.Description,  // thay doi
                                           CreatedDate = getTicket.CreatedDate,
                                           TranCreatedDate = getTicket.TranCreatedDate,
                                           TranModifiedDate = getTicket.TranModifiedDate,
                                           TranDescription = getTicket.TranDescription
                                       };
                this.unitOfWork.TicketRepository.AddOrUpdate(newTicket);
                this.unitOfWork.TicketRepository.Save();

                Session["Message"] = "Đã cập nhật vé thành công";
                return RedirectToAction("Manage");
            }
            ViewBag.EventId = new SelectList(this.unitOfWork.EventRepository.Get(), "EventId", "EventName",
                                             ticket.EventId);
            return View(ticket);
        }

        public ActionResult Manage()
        {
            var status = Request["status"];
            if (status == null) status = "0";
            var UserId = WebSecurity.GetUserId(User.Identity.Name);
            int CurrentStatus = Int32.Parse(status);
            ViewBag.CurrentStatus = CurrentStatus;
            var ticketList = unitOfWork.TicketRepository.Get(u => u.UserId == UserId && u.Status == CurrentStatus && u.TranStatus == null);
            return View(ticketList.ToList());
        }

        
        public ActionResult Delete(int Id)
        {
            Ticket oldTicket = Repository.GetById(Id);
            if (oldTicket.Status == (int)Statuses.Ticket.OnTransaction)
            {
                Session["Message"] = "Vé này đang giao dịch nên không thể sửa thông tin";
                return RedirectToAction("Manage");
            }
            try
            {

                oldTicket.Status = (int)Statuses.Ticket.Delete;
                Repository.AddOrUpdate(oldTicket);
                unitOfWork.Save();

                Session["Message"] = "Đã xóa vé thành công";
                return RedirectToAction("Manage");
            }
            catch (Exception e)
            {

                Session["Message"] = "Có lỗi trong quá trình xử lý. Xin liên hệ admin để cung cấp thông tin";
                return RedirectToAction("Manage");
            };
        }

        public ActionResult Details (int id=0)
        {
            Ticket ticket = this.unitOfWork.TicketRepository.GetById(id);
            if (ticket==null)
            {
                HttpNotFound();
            }
            return View(ticket);

        }

    }
}
