using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DropIt.Common;

namespace DropIt.ViewModels
{
    public class RequestTicket
    {
        public RequestTicket()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.CreateEvent = null;
            this.CreateVenue = null;
        }

        public int UserId { get; set; }

        public int? EventId { get; set; }

        public int Status { get; set; }

        public string Description { get; set; }

        [RequiredIf("CreateEvent", "checked", ErrorMessage = "Tên sự kiện phải có khi tạo sự kiện mới")]
        public string EventName { get; set; }

        [RequiredIf("CreateVenue", "checked", ErrorMessage = "Tên địa điểm phải có khi tạo địa điểm mới")]
        public string VenueName { get; set; }

        [RequiredIf("CreateVenue", "checked", ErrorMessage = "Địa chỉ nơi tổ chức phải có khi tạo địa điểm mới")]
        public string Address { get; set; }


        public int? ProvinceId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int? VenueId { get; set; }

        [DataType(DataType.Text)]
        [RequiredIf("CreateEvent", "checked", ErrorMessage = "Ngày tổ chức phải có khi tạo sự kiện mới")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? HoldDate { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public String CreateEvent;
        public String CreateVenue;
    }
}