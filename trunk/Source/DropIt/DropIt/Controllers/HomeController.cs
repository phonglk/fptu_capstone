using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EventRepository Repository;

        public HomeController()
        {
            Repository = unitOfWork.EventRepository;
        }

        public ActionResult Index()
        {
            if (Request["Role"] != null)
            {
                Session["Role"] = Request["Role"];
                return RedirectToAction("Index");
            }
            else if (Session["Role"] == null)
            {
                Session["Role"] = "Buy";
            }
            var events = this.unitOfWork.EventRepository.Get().OrderByDescending(t => t.Tickets.Count).Take(9).Where(p => p.Status == 1);
            return View(events.ToList());
        }

        public ActionResult Search(string eventnameofsearch)
        {
            var events = this.unitOfWork.EventRepository.Get();
            if (!String.IsNullOrEmpty(eventnameofsearch))
            {
                events = (from t in events
                          where t.EventName.ToLower().Contains(eventnameofsearch.ToLower())
                          orderby t.EventName
                          select t).ToList();
            }

            return View(events);

        }

        [ActionName("SearchAjax")]
        public JsonResult SearchAjax(string query)
        {
            var events = this.unitOfWork.EventRepository.Get();
            List<String> listeventname = new List<string>();
            if (!String.IsNullOrEmpty(query))
            {
                foreach (Event evt in events.ToList())
                {
                    if (evt.EventName.ToLower().Contains(query.ToLower()))
                    {
                        listeventname.Add(evt.EventName);
                    }
                }

            }
            return Json(new { query = query, suggestions = listeventname, data = listeventname }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GuideForNew()
        {
            return View();
        }
    }
}
