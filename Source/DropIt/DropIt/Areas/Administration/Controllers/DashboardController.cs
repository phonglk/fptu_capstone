using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Administration/Dashboard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
