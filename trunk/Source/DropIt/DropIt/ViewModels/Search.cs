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
        public int TotalCount = 0;
    }

    public class ResultEvent :IComparable<ResultEvent>{
        public int EventId { get; set; }

        public SearchResultTextField EventName = new SearchResultTextField();

        public string EventImage { get; set; }

        public SearchResultTextField Artist = new SearchResultTextField();

        public System.DateTime HoldDate { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public Venue Venue { get; set; }

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
            Venue = Event.Venue;
            CreatedDate = Event.CreatedDate;
            ModifiedDate = Event.ModifiedDate;
        }

        public int CompareTo(ResultEvent other)
        {
            if ((this.EventName.Matches.Count + this.Artist.Matches.Count) < (other.EventName.Matches.Count + other.Artist.Matches.Count))
            {
                return 1;
            }
            else if ((this.EventName.Matches.Count + this.Artist.Matches.Count) > (other.EventName.Matches.Count + other.Artist.Matches.Count))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int CompareTo(ResultEvent other,ResultEventComparer.ComparisonType comparisonMethod)
        {
            switch (comparisonMethod)
            {
                case ResultEventComparer.ComparisonType.Relevant :
                    return this.CompareTo(other);
                    break;
                case ResultEventComparer.ComparisonType.HoldDate :
                    if (this.HoldDate < other.HoldDate)
                    {
                        return 1;
                    }
                    else if (this.HoldDate > other.HoldDate)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                    break;
                default:
                    return this.CompareTo(other);
            }
        }

    }

    public class ResultEventComparer : IComparer<ResultEvent>
    {
        public enum ComparisonType
        {
            Relevant = 1,
            HoldDate = 2
        }

        public ComparisonType ComparisonMethod;


        public int Compare(ResultEvent x, ResultEvent y)
        {
            return x.CompareTo(y,ComparisonMethod);
        }
    }

    public class SearchResultTextField
    {
        public string Value { get; set; }
        public List<String> Matches = new List<String>();
    }
}