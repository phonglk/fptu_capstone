using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DropIt.DAL
{
    public class TransactionRepository : GenericRepository<Ticket>
    {
        public TransactionRepository(DropItContext context)
            : base(context)
        {

        }
    }
}
