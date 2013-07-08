using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using gfoidl.StringSearching;
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
            var events = this.unitOfWork.EventRepository.Get().OrderByDescending(t => t.Tickets.Count).Where(p => p.Status == 1).Take(10);
            return View(events.ToList());
        }

        public ActionResult Search(string eventnameofsearch)
        {
            var events = this.unitOfWork.EventRepository.Get();
            List<Event> foundEvent = new List<Event>();
            if (!String.IsNullOrEmpty(eventnameofsearch))
            {
                //events = (from t in events
                //          where t.EventName.ToLower().Contains(eventnameofsearch.ToLower())

                //            || t.Artist.ToLower().Contains(eventnameofsearch.ToLower())
                //            || t.Description.ToLower().Contains(eventnameofsearch.ToLower())
                //          select t).ToList();
                foreach (Event evt in events)
                {
                    List<string> listwords = new List<string>();
                    listwords.Add(evt.EventName.ToLower());
                    listwords.Add(evt.Artist == null ? "" : evt.Artist.ToLower());
                    listwords.Add(evt.Description == null ? "" : evt.Description.ToLower());

                    List<string> found = FuzzySearch.Search(eventnameofsearch.ToLower(), listwords, 0.40);
                    if (found.Count > 0)
                    {
                        foundEvent.Add(evt);
                    }
                }
            }

            return View(foundEvent);

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
                    if (ConvertVN(evt.EventName).ToLower().Contains(ConvertVN(query).ToLower()))
                    {
                        listeventname.Add(evt.EventName);
                    }
                    else if (ConvertVN(evt.Artist == null ? "" : evt.Artist).ToLower().Contains(ConvertVN(query).ToLower()))
                    {
                        if (!listeventname.Contains(evt.Artist))
                        { 
                            listeventname.Add(evt.Artist); 
                        }

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

        private string ConvertVN(string utf8text)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = utf8text.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(utf8text[index]);
                utf8text = utf8text.Replace(utf8text[index], ReplText[index2]);
            }
            return utf8text;
        }
    }
}
