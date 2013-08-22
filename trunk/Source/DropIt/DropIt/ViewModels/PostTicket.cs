using DropIt.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DropIt.Models;
using DropIt.DAL;

namespace DropIt.ViewModels
{
    public class PostTicket
    {
        public PostTicket()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.CreateEvent = null;
            this.CreateVenue = null;
//            this.MaxSellPrice = Double.Parse(Settings.get("MinSellPrice"));
//            this.MaxSellPrice = Double.Parse(Settings.get("MaxSellPrice"));
            
        }
//
//        public double MinSellPrice { get; set; }
//        public double MaxSellPrice { get; set; }
        public int TicketId { get; set; }
        
        public int? EventId { get; set; }

        [Required(ErrorMessage="Bạn phải nhập giá vé")]
        [CustomValidation(typeof(SellPriceValidate), "RangeSellPrice")]
        [RegularExpression("([0-9]*)", ErrorMessage = "Bạn hãy nhập số tiền!")]
        public double SellPrice { get; set; }

        [Required]
        public double ReceiveMoney { get; set; }

        public string Seat { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public string SeriesNumber { get; set; }

        [RequiredIf("CreateEvent","checked",ErrorMessage="Tên sự kiện phải có khi tạo sự kiện mới")]
        public string EventName { get; set; }

        [RequiredIf("CreateVenue", "checked", ErrorMessage = "Tên địa điểm phải có khi tạo địa điểm mới")]
        public string VenueName { get; set; }


        [RequiredIf("CreateVenue", "checked", ErrorMessage = "Địa chỉ nơi tổ chức phải có khi tạo địa điểm mới")]
        public string Address { get; set; }
        
        public int? ProvinceId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn thể loại!")]
        public int CategoryId { get; set; }

        public int? VenueId { get; set; }

        //[DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        [DataType(DataType.Text)]
        [RequiredIf("CreateEvent", "checked", ErrorMessage = "Ngày tổ chức phải có khi tạo sự kiện mới")]
        [FutureDate(ErrorMessage="Ngày tổ chức phải lớn hơn ngày hiện tại")]
        public DateTime? HoldDate { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public String CreateEvent;
        public String CreateVenue;

        [Required(ErrorMessage="Bạn phải đồng ý với điều khoản sử dụng")]
        public String AgreeTerm;

        public virtual Venue Venue { get; set; }
    }
    public class SuggestedEvent : IComparable<SuggestedEvent>
    {
        public double rate { get; set; }
        public Event Event { get; set; }
        public Boolean isMatchVenue { get; set; }
        public Boolean isMatchTimeRange { get; set; }
        public Boolean isMatchTime { get; set; }
        public Boolean isMatchDate { get; set; }

        public SuggestedEvent()
        {
            rate = 0;
            Event = null;
            isMatchDate = isMatchTime = isMatchTimeRange = isMatchVenue = false;
        }

        public int CompareTo(SuggestedEvent other)
        {
            if (this.rate < other.rate)
            {
                return 1;
            }
            else if (this.rate > other.rate)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}