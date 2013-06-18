using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class RequestRepository : GenericRepository<Request>
    {
        public RequestRepository(DropItContext context)
            : base(context)
        {

        }
    }
}