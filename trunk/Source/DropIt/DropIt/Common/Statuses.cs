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
        public enum Ticket { Pending,Ready,Delete, UserApprove, OnTransaction, Done};
        public static String[] TicketStrings = new string[] {"Chưa được phép", "Được phép", "",""};
        public static String[] TicketString2 = new string[] { "Chưa được phép", "Được phép", "", "Đang đợi chấp nhận" };
        public enum Event { Disapprove, Approve, Delete, Trading , Outdate };
        public enum Venue { Disapprove, Approve, Delete };
        public enum Transaction { Unpaid, Paid, Delivered, Received, Canceled};
        public static String[] BuyTicketStrings = new string[] { "Chưa thanh toán", "Đã Mua","Đã giao","Đã nhận","Đã hủy" };
        public enum TranType { InstantPayment, HoldPayment};
        public enum Request { Open, Close};
        public enum Response { Appear, Delete};
        public enum Category { Deactive, Active, Delete };
        public enum Payment { Hold ,Transfered, Done };
        public enum FollowType { Sell,Buy,SellAndBuy }

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