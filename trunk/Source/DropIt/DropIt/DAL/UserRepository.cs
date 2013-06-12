using System.Data;
using System.Data.Entity;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Diagnostics;
using DropIt.Filters;
using WebMatrix.WebData;

namespace DropIt.DAL
{
    [InitializeSimpleMembership]
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DropItContext context) : base(context)
        {
            
        }        
    }
}