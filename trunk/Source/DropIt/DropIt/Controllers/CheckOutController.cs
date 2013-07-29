using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;

namespace DropIt.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CheckOutController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TicketRepository Repository;

        public CheckOutController()
        {
            Repository = unitOfWork.TicketRepository;
        }

        public ActionResult Checkout(int Id)
        {
            double dollarRate = double.Parse(Settings.get("DollarRate"));
            ViewBag.TicketId = Id;
            Ticket ticket = unitOfWork.TicketRepository.GetById(Id);
            double shippingCost;
            if (ticket.ShippingCost==null)
            {
                 shippingCost = double.Parse(Settings.get("ShippingCost"));
            }
            else
            {
                 shippingCost = (double)ticket.ShippingCost;
            }
            string eventname = Utils.ConvertVN(ticket.Event.EventName);
            PDTHolder pp = new PDTHolder()
                            {
                                item_name = eventname,
                                amount = System.Math.Round((ticket.SellPrice / dollarRate),2),
                                shipping = System.Math.Round((shippingCost / dollarRate), 2),
                                custom = ticket.TicketId,
                            };
            return View(pp);
        }


        public ActionResult Success()
        {
            string authToken, txToken, query;
            string strResponse;

            if (Request.HttpMethod != "POST")
            {
                authToken = WebConfigurationManager.AppSettings["PDTToken"];

                // read in txn token from querystring
                txToken = Request.QueryString.Get("tx");

                query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);

                // crate the request back
                string url = WebConfigurationManager.AppSettings["PayPalSubmitUrl"];

                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(url);

                // Set values for the request back
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = query.Length;

                // Write the request back IPN strings
                StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                stOut.Write(query);
                stOut.Close();

                // Do the request to PayPal and get the response
                StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
                strResponse = stIn.ReadToEnd();
                stIn.Close();

                // If response was SUCCESS, parse response string and output details
                if (strResponse.StartsWith("SUCCESS"))
                {
                    PDTHolder pdt = PDTHolder.Parse(strResponse);
                    int pTicketId = int.Parse(pdt.Custom);
//                    ViewBag.Text = string.Format("Thank you {0} {1} [{2}] for your payment of {3} {4}!",
//                        pdt.PayerFirstName, pdt.PayerLastName, pdt.PayerEmail, pdt.GrossTotal, pdt.Custom);

                    Ticket ticket = this.unitOfWork.TicketRepository.Get(t => t.TicketId == pTicketId).FirstOrDefault();
                    if (ModelState.IsValid)
                    {
                        if (ticket.TranStatus==null)
                        {
                            if (ticket.TranType==(int)Statuses.TranType.InstantPayment)
                            {
                                Ticket checkout = new Ticket()
                                {
                                    TicketId = ticket.TicketId,
                                    SeriesNumber = ticket.SeriesNumber,
                                    TranUserId = ticket.TranUserId,
                                    TranFullName = ticket.TranFullName,
                                    TranAddress = ticket.TranAddress,
                                    TranType = ticket.TranType,
                                    TranStatus = (int)Statuses.Transaction.Paid,
                                    EventId = ticket.EventId,
                                    UserId = ticket.UserId,
                                    SellPrice = ticket.SellPrice,
                                    ReceiveMoney = ticket.ReceiveMoney,
                                    ShippingCost = ticket.ShippingCost,
                                    Seat = ticket.Seat,
                                    Status = ticket.Status,
                                    Description = ticket.Description,
                                    CreatedDate = ticket.CreatedDate,
                                    TranCreatedDate = ticket.TranCreatedDate,
                                    TranModifiedDate = DateTime.Now,
                                    TranDescription = ticket.TranDescription,
                                    TranPaymentStatus = (int)Statuses.Payment.Transfered
                                };
                                this.unitOfWork.TicketRepository.AddOrUpdate(checkout);
                                this.unitOfWork.Save();  
                            }
                            else
                            {
                                Ticket checkout = new Ticket()
                                {
                                    TicketId = ticket.TicketId,
                                    SeriesNumber = ticket.SeriesNumber,
                                    TranUserId = ticket.TranUserId,
                                    TranFullName = ticket.TranFullName,
                                    TranAddress = ticket.TranAddress,
                                    TranType = ticket.TranType,
                                    TranStatus = (int)Statuses.Transaction.Paid,
                                    EventId = ticket.EventId,
                                    UserId = ticket.UserId,
                                    SellPrice = ticket.SellPrice,
                                    ReceiveMoney = ticket.ReceiveMoney,
                                    ShippingCost = ticket.ShippingCost,
                                    Seat = ticket.Seat,
                                    Status = ticket.Status,
                                    Description = ticket.Description,
                                    CreatedDate = ticket.CreatedDate,
                                    TranCreatedDate = ticket.TranCreatedDate,
                                    TranModifiedDate = DateTime.Now,
                                    TranDescription = ticket.TranDescription
                                };
                                this.unitOfWork.TicketRepository.AddOrUpdate(checkout);
                                this.unitOfWork.Save();  
                            }
                                                  
                        }
                        else
                        {
                            return View("Error");
                        }
                        
                    }
                }
                else
                {
                    ViewBag.Text = "Cố lỗi xảy ra";
                }

            }

            return View();
        }

    }
}
