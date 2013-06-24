using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Models
{
    public class Status
    {
        private int Code;
        public string Text { get; set; }
        public Status(int code)
        {
            this.Code = code;
        }
        public Status(int code,string text)
        {
            Code = code;
            Text = text;
        }
    }
}