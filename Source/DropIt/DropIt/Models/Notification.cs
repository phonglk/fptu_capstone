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
    
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SenderId { get; set; }
        public string ActivityType { get; set; }
        public string ObjectType { get; set; }
        public string ObjectTitle { get; set; }
        public string ObjectUrl { get; set; }
        public string Content { get; set; }
        public bool IsUnread { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual User User { get; set; }
    }
}