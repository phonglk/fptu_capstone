using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Hubs;
using DropIt.Filters;
using System.Drawing;
using DropIt.DAL;
namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
    public class DashboardController : Controller
    {
        //
        // GET: /Administration/Dashboard/
        private UnitOfWork unitOfWork = new UnitOfWork();
        

        public ActionResult Index()
        {
            ICollection<string> UserList = NotificationHub.HubUsers.Keys;
            ViewBag.UserOnlineList = UserList;

            //List<Point> data = new List<Point>();
            //List<String> label = new List<String>();
            String dataSell = "[";
            String dataPost = "[";
            String label = "[";
            int numDayToStatistic = 7;
            DateTime earlyDate = DateTime.Now.AddDays(-numDayToStatistic);
            for (int i = 0; i < numDayToStatistic; i++)
            {
                DateTime doDate = earlyDate.AddDays(i);
                int ticketSell = unitOfWork.TicketRepository.Get(t => t.TranStatus != null && t.TranCreatedDate.Value.Day == doDate.Day).Count();
                int ticketPost = unitOfWork.TicketRepository.Get(t => t.CreatedDate.Value.Day == doDate.Day).Count();
                if (i != 0)
                {
                    dataSell += ",";
                    dataPost += ",";
                    label += ",";
                }
                dataSell += String.Format("[{0},{1}]", i, ticketSell);
                dataPost += String.Format("[{0},{1}]", i, ticketPost);
                label += String.Format("[{0},\"{1}\"]", i, doDate.ToString("dd/MM/yyyy"));
            }

            dataSell += "]";
            dataPost += "]";
            label += "]";

            ViewBag.TicketSellData = dataSell;
            ViewBag.TicketPostData = dataPost;
            ViewBag.TicketSellDataLabel = label;


            return View();
        }

    }
}
