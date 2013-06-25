using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Common
{
    public static class Statuses
    {
        public enum UserActive { Deactive, Active, Delete };
        public enum UserSellable { True,False };
        public enum Ticket { Disapprove,Approve,Delete };
        public enum Event { Disapprove, Approve, Delete };
        public enum Venue { Disapprove, Approve, Delete };
        public enum BuyTicket { Unpaid, Paid, Delivered, Recieved, Cancel};
        public enum TranType { InstantPayment, HoldPayment};
    }
}