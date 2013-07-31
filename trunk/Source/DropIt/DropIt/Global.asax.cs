using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DropIt.DAL;
using DropIt.Common;
using System.Diagnostics;
using DropIt.Hubs;
using Microsoft.AspNet.SignalR;
using System.Timers;
using System.Threading;

namespace DropIt
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static CacheItemRemovedCallback OnCacheRemove = null;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private int AutomationStick = 0;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteTable.Routes.MapHubs();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableDateTimeBinder());

            DropIt.Common.AdminMenu.Init();


            var waitHandle = new AutoResetEvent(false);
            ThreadPool.RegisterWaitForSingleObject(
                waitHandle,
                (state, timeout) =>
                {
                    AutomationStick++;
                    if (AutomationStick > 100)
                    {
                        AutomationStick = 1;
                    }
                    if (AutomationStick % 10 == 0)
                    {

                        //CheckEventExpire
                        var EventsNeedExpire = unitOfWork.EventRepository.Get(e => e.Status != (int)Statuses.Event.Outdate && e.Status != (int)Statuses.Event.Delete && e.HoldDate <= DateTime.Now);
                        foreach (Event Event in EventsNeedExpire)
                        {
                            Event.Status = (int)Statuses.Event.Outdate;
                            unitOfWork.EventRepository.AddOrUpdate(Event);
                        }
                        unitOfWork.Save();

                    }
                    else if (AutomationStick % 5 == 0)
                    {
                        //PayHoldCheck
                        try
                        {
                            UnitOfWork unitOfWork2 = new UnitOfWork();
                            var yesterday = DateTime.Now.AddDays(-5);
                            var tranHoldPayment = unitOfWork2.TicketRepository.Get(t => t.TranType == (int)Statuses.TranType.HoldPayment);
                            var checkTranShipDate = tranHoldPayment.Where(t => t.TranShipDate != null);
                            var rr = checkTranShipDate.Where(t => t.TranPaymentStatus == null);
                            var getTran = rr.Where(t => t.TranShipDate <= yesterday);
                            foreach (Ticket ticket in getTran.ToList())
                            {
                                ticket.TranPaymentStatus = (int)Statuses.Payment.Transfered;
                                unitOfWork2.TicketRepository.AddOrUpdate(ticket);
                                unitOfWork2.TicketRepository.Save();
                            }
                        }
                        catch (Exception)
                        {
                        }

                    }
                    else if (AutomationStick % 2 == 0)
                    {
                        SimulateNotification();
                    }
                },
                null,
                TimeSpan.FromSeconds(1),
                false
            );

        }

        private void SimulateNotification()
        {
            return;
            try
            {
                NotificationHub.Send(new
                {
                    Type = "Notification",
                    Object = new
                    {
                        ActivityType = "Add",
                        CreatedDate = "/Date(1375181011637)/",
                        IsUnread = true,
                        ModifiedDate = "/Date(1375181011637)/",
                        NotificationId = 2,
                        ObjectTitle = "Đêm nhạc 'Như vẫn còn đây'",
                        ObjectType = "Event",
                        ObjectUrl = "/Event/Details/31",
                        SenderId = 31,
                        UserId = 10
                    }
                });
            }
            catch (Exception e)
            {

            }
        }
    }
}