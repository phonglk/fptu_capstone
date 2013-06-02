using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropIt.Models;

namespace DropIt.DAL
{
    public class BaseRepository
    {
        protected DropItContext ctx;

        public BaseRepository()
        {
            ctx = new DropItContext();
        }

        public BaseRepository(DropItContext ctx)
        {
            this.ctx = ctx;
        }

        protected User GetCurrentUser()
        {
            try
            {
                return ctx.Users.First(u => u.UserName.Equals(HttpContext.Current.User.Identity.Name));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}