using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Contants
{
    public static class Constant
    {

        public const int STATUS_INACTIVE = 0;
        public const int STATUS_ACTIVE = 1;

        public const int TRANS_STATUS_READY = 1;
        public const int TRANS_STATUS_SHIPPED = 2;
        public const int TRANS_STATUS_CONFIRMED = 3;
        public const int TRANS_STATUS_CANCELLED = 4;

        public const int PAGE_SIZE = 10;

        public const string ST_OK = "OK";
        public const string ST_NG = "NG";
        
    }
}