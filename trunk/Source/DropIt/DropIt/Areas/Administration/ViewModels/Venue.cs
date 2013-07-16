using DropIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DropIt.Areas.Administration.ViewModels
{
    public class VenueViewModel
    {
        public int VenueId { get; set; }
        [Required(ErrorMessage = "Bạn cần điền tên địa điểm")]
        public string VenueName { get; set; }
        [Required(ErrorMessage = "Bạn cần điền địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn tỉnh/thành phố")]
        public int ProvinceId { get; set; }
        public int Status { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public int EventId { get; set; }

    }
}