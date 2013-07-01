﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel;
    
    public partial class Request
    {
        public Request()
        {
            this.TicketResponses = new HashSet<TicketResponse>();
        }
    
        public int UserId { get; set; }
        public int EventId { get; set; }
        [DisplayName ("Trạng thái: ")]
        public int Status { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TicketResponse> TicketResponses { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
