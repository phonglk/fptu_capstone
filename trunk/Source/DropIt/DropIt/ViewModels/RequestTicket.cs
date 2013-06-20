using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class RequestTicket
    {
        public RequestTicket()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        public int UserId { get; set; }

        public int? EventId { get; set; }

        public int Status { get; set; }

        public string Description { get; set; }

        public string EventName { get; set; }

        public string VenueName { get; set; }

        public string Address { get; set; }

        public int? ProvinceId { get; set; }

        public int CategoryId { get; set; }

        public int? VenueId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? HoldDate { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}