using System.Data;
using System.Data.Entity;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.DAL
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DropItContext context) : base(context)
        {
            
        }
        
        //public void UpdateUserInfo(User user)
        //{
        //    var u = context.Users.Where(m => m.UserId == user.UserId).AsNoTracking().FirstOrDefault();
        //    user.Address = u.Address;
        //    user.Email = u.Email;
        //    user.ProvinceId = u.ProvinceId;
        //    user.Phone = u.Phone;
        //    context.Entry(user).State=EntityState.Modified;
        //}
    }
}