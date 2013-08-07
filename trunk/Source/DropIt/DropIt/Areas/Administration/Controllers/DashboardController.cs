﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Hubs;
using DropIt.Filters;
namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
    public class DashboardController : Controller
    {
        //
        // GET: /Administration/Dashboard/

        public ActionResult Index()
        {
            ICollection<string> UserList = NotificationHub.HubUsers.Keys;
            ViewBag.UserOnlineList = UserList;
            return View();
        }

    }
}
