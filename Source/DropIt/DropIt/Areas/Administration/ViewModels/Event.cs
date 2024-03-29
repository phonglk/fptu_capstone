﻿using DropIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        [Required(ErrorMessage="Bạn cần điền tên sự kiện")]
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public string Artist { get; set; }

        [Required(ErrorMessage="Bạn cần điền ngày tổ chức")]
        public System.DateTime HoldDate { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "Bạn cần điền danh mục")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn cần điền địa điểm")]
        public int VenueId { get; set; }

        public bool haveTicketTran { get; set; }
    }
}