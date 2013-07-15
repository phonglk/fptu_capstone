using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;

namespace DropIt.DAL
{
    public class VenueRepository: GenericRepository<Venue>
    {
        public VenueRepository(DropItContext context)
            : base(context)
        {

        }
    }
}