//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DropIt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public Ticket()
        {
            this.TicketResponses = new HashSet<TicketResponse>();
        }
    
        public int TicketId { get; set; }
        public string SeriesNumber { get; set; }
        public double SellPrice { get; set; }
        public double ReceiveMoney { get; set; }
        public Nullable<double> ShippingCost { get; set; }
        public string Seat { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public Nullable<System.DateTime> AdminModifiedDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string TranFullName { get; set; }
        public Nullable<int> TranType { get; set; }
        public Nullable<System.DateTime> TranShipDate { get; set; }
        public string TranDescription { get; set; }
        public string TranAddress { get; set; }
        public Nullable<int> TranStatus { get; set; }
        public Nullable<int> TranUserId { get; set; }
        public Nullable<System.DateTime> TranCreatedDate { get; set; }
        public Nullable<System.DateTime> TranModifiedDate { get; set; }
        public Nullable<double> TranDeliveryServiceCost { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual ICollection<TicketResponse> TicketResponses { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
