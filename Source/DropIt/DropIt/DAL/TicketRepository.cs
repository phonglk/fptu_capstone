using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DropIt.DAL
{
    public class TicketRepository : GenericRepository<Ticket>
    {
        public TicketRepository(DropItContext context)
            : base(context)
        {

        }
    }
}
