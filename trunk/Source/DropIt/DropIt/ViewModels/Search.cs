using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class SearchResultViewModel
    {
        public List<ResultEvent> Result = new List<ResultEvent>();
    }

    public class ResultEvent{
        public int EventId { get; set; }

        public SearchResultTextField EventName = new SearchResultTextField();

        public string EventImage { get; set; }

        public SearchResultTextField Artist = new SearchResultTextField();

        public System.DateTime HoldDate { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string VenueName { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public ResultEvent(Event Event)
        {
            EventId = Event.EventId;
            EventName.Value = Event.EventName;
            EventImage = Event.EventImage;
            Artist.Value = Event.Artist;
            HoldDate = Event.HoldDate;
            Description = Event.Description;
            Status = Event.Status;
            VenueName = Event.Venue.VenueName;
            CreatedDate = Event.CreatedDate;
            ModifiedDate = Event.ModifiedDate;
        }
    }

    public class SearchResultTextField
    {
        public string Value { get; set; }
        public List<String> Matches = new List<String>();
    }
}