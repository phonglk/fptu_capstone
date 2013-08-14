using DropIt.Common;
using DropIt.Models;
using DropIt.ViewModels;
using gfoidl.StringSearching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class EventRepository : GenericRepository<Event>
    {
        private UnitOfWork uow = new UnitOfWork();
        public EventRepository(DropItContext context)
            : base(context)
        {

        }

        public IEnumerable<Event> GetAvailable()
        {
            return this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate && e.Status != (int)Statuses.Event.Disapprove);
        }

        public IEnumerable<Event> GetAvailableIncludingDisapprove()
        {
            return this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate);
        }

        public IEnumerable<Event> GetRequestAvailable(int UserId)
        {
            var events = uow.UserRepository.GetById(UserId).Requests.Select(t => t.Event);
            var event2 = this.Get(e => e.Status != (int)Statuses.Event.Delete && e.Status != (int)Statuses.Event.Outdate).SkipWhile(e => events.FirstOrDefault(x => x.EventId == e.EventId) != null);
            return event2;
        }

        public SearchResultViewModel Search(string query, IEnumerable<Event> events, string sortBy = "relevant")
        {
            SearchResultViewModel foundEvent = new SearchResultViewModel();
            if (!String.IsNullOrEmpty(query))
            {
                foreach (Event evt in events)
                {
                    List<String> splittedEvent = new List<String>();
                    String eventName = evt.EventName;
                    for (var i = 0; i <= eventName.Length - query.Length; i++)
                    {
                        splittedEvent.Add(eventName.Substring(i, query.Length));
                    }

                    List<string> foundbyTitle = FuzzySearch.Search(query.ToLower(), splittedEvent, 0.50);

                    List<String> splittedArtist = new List<String>();

                    List<string> foundbyArtist = new List<string>();
                    if (evt.Artist != null)
                    {
                        String Artist = evt.Artist;
                        for (var i = 0; i <= Artist.Length - query.Length; i++)
                        {
                            splittedArtist.Add(Artist.Substring(i, query.Length));
                        }

                        foundbyArtist = FuzzySearch.Search(query.ToLower(), splittedArtist, 0.5);
                    }

                    if (foundbyTitle.Count > 0 || foundbyArtist.Count > 0)
                    {
                        ResultEvent Event = new ResultEvent(evt);
                        Event.EventName.Matches = Utils.ReduceRedundancy(foundbyTitle);
                        Event.Artist.Matches = Utils.ReduceRedundancy(foundbyArtist);

                        foundEvent.Result.Add(Event);
                    }
                    else
                    {
                        if (Utils.ConvertVN(evt.EventName).ToLower().Contains(Utils.ConvertVN(query.ToLower())))
                        {
                            ResultEvent Event = new ResultEvent(evt);
                            Event.EventName.Matches = new List<string>{
                                query
                            };
                            Event.IsFuzz = false;
                            foundEvent.Result.Add(Event);
                        }
                    }
                }



                ResultEventComparer comparer = new ResultEventComparer();

                if (sortBy == "relevant")
                {
                    comparer.ComparisonMethod = ResultEventComparer.ComparisonType.Relevant;
                    foundEvent.Result.Sort(comparer);
                }
                else if (sortBy == "HoldDate")
                {
                    comparer.ComparisonMethod = ResultEventComparer.ComparisonType.HoldDate;
                    foundEvent.Result.Sort(comparer);
                }

                return foundEvent;

            }
            return null;
        }

        public List<SuggestedEvent> Suggestion(String EventName, int CategoryId, DateTime HoldDate, int VenueId)
        {
            var Events = uow.EventRepository.GetAvailableIncludingDisapprove();
            List<SuggestedEvent> suggestion = new List<SuggestedEvent>();
            foreach (Event Event in Events)
            {
                double mark = 0;
                var suggest = new SuggestedEvent()
                    {
                        Event = Event
                    };
                if (Event.VenueId == VenueId)
                {
                    mark += 0.3;
                    suggest.isMatchVenue = true;

                }
                if (Event.CategoryId == CategoryId)
                {
                    mark += 0.1;
                }
                if (Event.HoldDate.Date == HoldDate.Date)
                {
                    suggest.isMatchDate = true;
                }
                TimeSpan timeRange = Event.HoldDate - HoldDate;
                double rangeInMinute = Math.Abs(timeRange.TotalMinutes);
                int acceptanceRange = 6 * 60;
                if (rangeInMinute < acceptanceRange)
                {
                    
                    suggest.isMatchTimeRange = true;
                    if (rangeInMinute == 0)
                    {
                        suggest.isMatchTime = true;
                    }
                    double timeRatio = 0.2;
                    double timeSimilarRatio = (acceptanceRange - timeRange.Minutes) / acceptanceRange;
                    mark += timeRatio * timeSimilarRatio;

                    if (Event.VenueId == VenueId)
                    {
                        mark += timeRatio * timeSimilarRatio;
                    }
                }

                if (mark >= 0.3)
                {
                    suggest.rate = mark;
                    suggestion.Add(suggest);
                }
            }

            suggestion.Sort();

            return suggestion;
        }
    }
}