using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;
using DropIt.Common;

namespace DropIt.DAL
{
    public class VenueRepository: GenericRepository<Venue>
    {
        public VenueRepository(DropItContext context)
            : base(context)
        {

        }

        public IEnumerable<Venue> GetAvailable()
        {
            return this.Get(e => e.Status != (int)Statuses.Venue.Delete);
        }
    }
}