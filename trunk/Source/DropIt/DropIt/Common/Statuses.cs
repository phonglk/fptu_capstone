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
        public enum Ticket { Disapprove,Approve,Delete, UserApprove };
        public static String[] TicketStrings = new string[] {"Chưa được phép", "Được phép", "",""};
        public enum Event { Disapprove, Approve, Delete };
        public enum Venue { Disapprove, Approve, Delete };
        public enum BuyTicket { Unpaid, Paid, Delivered, Recieved, Canceled};
        public static String[] BuyTicketStrings = new string[] { "Chưa thanh toán", "Đã Mua","Đã giao","Đã nhận","Đã hủy" };
        public enum TranType { InstantPayment, HoldPayment};
        public enum Request { Open, Close};

        public static string getText(String EnumName, int Value)
        {
            try
            {
                String[] StatusText = (String[])typeof(Statuses).GetField(EnumName).GetValue(null);
                return StatusText[Value];
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }

}