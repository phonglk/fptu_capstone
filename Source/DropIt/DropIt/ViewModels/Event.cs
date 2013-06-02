using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using System.ComponentModel.DataAnnotations;
namespace DropIt.ViewModels
{
    public class CreateEvent
    {
        public CreateEvent()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime HoldDate { get; set; }

        public string Description { get; set; }
        
        [Required]
        public int Status { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Required]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}