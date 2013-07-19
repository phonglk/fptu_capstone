using DropIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DropIt.Areas.Administration.ViewModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Bạn cần điền giá vé")]
        public float SellPrice { get; set; }
        public string Seat { get; set; }
        public float ReceiveMoney { get; set; }
        public string SeriesNumber { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bạn cần điền tên sự kiện")]
        public int EventId { get; set; }
        //public string TranFullName { get; set; }
        //public int TranType { get; set; }
        //public string TranDescription { get; set; }
        //public string TranAddress { get; set; }
        //public System.DateTime TranShipDate { get; set; }
        //public int TranStatus { get; set; }
        //public int TranUserId { get; set; }
    }
}