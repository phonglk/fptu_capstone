using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DropIt.Areas.Administration.ViewModels
{
    public class RequestViewModel
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}