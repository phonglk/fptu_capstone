using DropIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.ViewModels
{
    public class TransactionViewModel
    {
        public int TicketId { get; set; }
        public float SellPrice { get; set; }
        public int UserId { get; set; }
        public string TranFullName { get; set; }
        public int TranType { get; set; }
        public string TranDescription { get; set; }
        public string TranAddress { get; set; }
        public float ShippingCost { get; set; }
        public string TranShipCode { get; set; }
        public float ReceiveMoney { get; set; }
        public int TranPaymentStatus { get; set; }
        public System.DateTime TranShipDate { get; set; }
        public int TranStatus { get; set; }
        public int TranUserId { get; set; }
    }
}