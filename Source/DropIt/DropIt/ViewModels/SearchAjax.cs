using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class SearchAjax
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Artist { get; set; }
        public string EventImage { get; set; }
        public int Status { get; set; }
    }
}