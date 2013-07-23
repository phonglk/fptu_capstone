using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using DropIt.ViewModels;
using gfoidl.StringSearching;
using System;
using System.Collections;
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
            Session["Role"] = "Event";
            var events = this.unitOfWork.EventRepository.Get().OrderByDescending(t => t.Tickets.Count).Where(p => p.Status != 2 || p.Status!=4).Take(10);
            return View(events.ToList());
        }

        public ActionResult NearEvent()
        {
            Session["Role"] = "Event";
            var eventAll = this.unitOfWork.EventRepository.Get().Where(p => p.HoldDate != null);
            var topEvent = eventAll.Where(p => p.HoldDate >= DateTime.Now).OrderBy(p=>p.HoldDate).Take(10);
            
            return View(topEvent);
        }

        [ActionName("Buy")]
        public ActionResult BuyIndex()
        {
            Session["Role"] = "Buy";
            return View();
        }

        [ActionName("Sell")]
        public ActionResult SellIndex()
        {
            Session["Role"] = "Sell";
            return View();
        }

        private List<string> ReduceRedundancy(List<string> strings)
        {
            List<string> result = new List<string>();

            foreach (string str in strings)
            {
                var str_c1 = str.ToLower().Trim();
                bool IsSame = false;
                foreach (string str2 in result)
                {
                    var str_c2 = str2.ToLower().Trim();
                    if (str_c1.Equals(str_c2))
                    {
                        IsSame = true;
                    }
                    if (str_c1.IndexOf(str_c2) > -1)
                    {
                        IsSame = true;
                    }
                    if (str_c2.IndexOf(str_c1) > -1)
                    {
                        IsSame = true;
                    }
                }
                if (IsSame == false)
                {
                    result.Add(str);
                }
            }

            return result;
        }

        public ActionResult Search(string query, string sortBy = "relevant")
        {
            var events = this.unitOfWork.EventRepository.Get(e => e.Status != (int)Statuses.Event.Disapprove && e.Status != (int)Statuses.Event.Delete);
            SearchResultViewModel foundEvent = new SearchResultViewModel();
            if (!String.IsNullOrEmpty(query))
            {
                //events = (from t in events
                //          where t.EventName.ToLower().Contains(eventnameofsearch.ToLower())

                //            || t.Artist.ToLower().Contains(eventnameofsearch.ToLower())
                //            || t.Description.ToLower().Contains(eventnameofsearch.ToLower())
                //          select t).ToList();
                foreach (Event evt in events)
                {
                    List<String> splittedEvent = new List<String>();
                    String eventName = evt.EventName;
                    for (var i = 0; i <= eventName.Length - query.Length; i++)
                    {
                        splittedEvent.Add(eventName.Substring(i, query.Length));
                    }

                    List<string> foundbyTitle = FuzzySearch.Search(query.ToLower(), splittedEvent, 0.50);

                    List<String> splittedArtist = new List<String>();

                    List<string> foundbyArtist = new List<string>();
                    if (evt.Artist != null)
                    {
                        String Artist = evt.Artist;
                        for (var i = 0; i <= Artist.Length - query.Length; i++)
                        {
                            splittedArtist.Add(Utils.ConvertVN(Artist.Substring(i, query.Length)));
                        }

                        foundbyArtist = FuzzySearch.Search(query.ToLower(), splittedArtist, 0.5);
                    }

                    if (foundbyTitle.Count > 0 || foundbyArtist.Count > 0)
                    {
                        ResultEvent Event = new ResultEvent(evt);
                        Event.EventName.Matches = ReduceRedundancy(foundbyTitle);
                        Event.Artist.Matches = ReduceRedundancy(foundbyArtist);

                        foundEvent.Result.Add(Event);
                    }
                }


                ResultEventComparer comparer = new ResultEventComparer();

                if (sortBy == "relevant")
                {
                    comparer.ComparisonMethod = ResultEventComparer.ComparisonType.Relevant;
                    foundEvent.Result.Sort(comparer);
                }
                else if (sortBy == "HoldDate")
                {
                    comparer.ComparisonMethod = ResultEventComparer.ComparisonType.HoldDate;
                    foundEvent.Result.Sort(comparer);
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
                    if (Utils.ConvertVN(evt.EventName).ToLower().Contains(Utils.ConvertVN(query).ToLower()))
                    {
                        listeventname.Add(evt.EventName);
                    }
                    else if (Utils.ConvertVN(evt.Artist == null ? "" : evt.Artist).ToLower().Contains(Utils.ConvertVN(query).ToLower()))
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
    }
}
