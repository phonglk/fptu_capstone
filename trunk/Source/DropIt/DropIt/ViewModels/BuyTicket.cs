using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DropIt.Models;

namespace DropIt.ViewModels
{
    public class BuyTicket
    {
        [Required(ErrorMessage = "Bạn chưa nhập họ tên nhận hàng")]
        public string TranFullName { get; set; }

        [Required]
        public int? TranType { get; set; }

        public int UserId { get; set; }

        public double SellPrice { get; set; }

        public double ReceiveMoney { get; set; }

        public string Seat { get; set; }

        public string Description { get; set; }
        public int TicketId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TranShipDate { get; set; }

        public string TranDescription { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ giao hàng")]
        public string TranAddress { get; set; }

        public int TranStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        
        public string EventName { get; set; }
        public DateTime HoldDate { get; set; }
        public string VenueName { get; set; }
    }
}