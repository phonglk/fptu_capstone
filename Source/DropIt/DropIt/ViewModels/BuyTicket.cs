using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class BuyTicket
    {
        public string TranFullName { get; set; }
        public int? TranType { get; set; }
        public int UserId { get; set; }
        public double ReceiveMoney { get; set; }
        public int TicketId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TranShipDate { get; set; }

        public string TranDescription { get; set; }
        public string TranAddress { get; set; }
        public int TranStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}