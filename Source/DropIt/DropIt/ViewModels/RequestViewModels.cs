﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.ComponentModel.DataAnnotations;
using DropIt.DAL;

namespace DropIt.ViewModels
{
    public class RequestViewModels
    {
        public RequestViewModels()
        {
            this.TicketResponses = new HashSet<TicketResponse>();
        }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn sự kiện!")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn trạng thái!")]
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