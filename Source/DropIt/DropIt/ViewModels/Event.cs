using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.ComponentModel.DataAnnotations;
namespace DropIt.ViewModels
{
    public class CreateEvent
    {
        public CreateEvent()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        public int EventId { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên sự kiện!")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn thời điểm tổ chức sự kiện!")]
        [DataType(DataType.DateTime)]
        public System.DateTime HoldDate { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn trạng thái!")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn thể loại!")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn địa điểm tổ chức!")]
        public int VenueId { get; set; }

        
        public Nullable<System.DateTime> CreatedDate { get; set; }
        
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }

    public class PagingData
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }

    }
}