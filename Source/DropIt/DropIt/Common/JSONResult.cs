using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Common
{
    public class JSONResult
    {
        public bool IsOK { get; set; }
        public String Reason { get; set; }
        public Object Result { get; set; }
    }
}