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

namespace DropIt
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static CacheItemRemovedCallback OnCacheRemove = null;
        private UnitOfWork unitOfWork = new UnitOfWork();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableDateTimeBinder());

            DropIt.Common.AdminMenu.Init();

            AddTask("CheckEventExpire", 10);
            AddTask("PayHoldCheck",5);
        }

        private void AddTask(string name, int seconds)
        {
            OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
            HttpRuntime.Cache.Insert(name, seconds, null,
                DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
        {
            if(k.Equals("CheckEventExpire")){


                var EventsNeedExpire = unitOfWork.EventRepository.Get(e => e.Status != (int)Statuses.Event.Outdate && e.Status != (int)Statuses.Event.Delete && e.HoldDate <= DateTime.Now);
                foreach (Event Event in EventsNeedExpire)
                {
                    Event.Status = (int)Statuses.Event.Outdate;
                    unitOfWork.EventRepository.AddOrUpdate(Event);
                }
                unitOfWork.Save();
                
            }
            else if (k.Equals("PayHoldCheck"))
            {
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
            
            AddTask(k, Convert.ToInt32(v));
        }
    }
}