using DropIt.Common;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.DAL
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DropItContext context)
            : base(context)
        {
             
        }

        public IEnumerable<Category> GetAvailable()
        {
            return this.Get(e => e.Status == (int)Statuses.Category.Active);
        }
    }
}