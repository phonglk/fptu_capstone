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
using DropIt.Common;

namespace DropIt.DAL
{
    [InitializeSimpleMembership]
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DropItContext context) : base(context)
        {
            
        }

        public double Rating(int UserId)
        {
            User user = this.GetById(UserId);
            if (user != null)
            {
                return Rating(user);
            }
            return 0.0;
        }
        public double Rating(User user){
            double maximumRating = 5;
            double ratio = 0;
            double sellingRatio = 0;
            double buyingRatio = 0;

            int countBuy = user.Tickets1.Where(t=>t.TranStatus != null).Count();
            int countTotalSell = user.Tickets.Count();
            int countInvalidSell = user.Tickets.Where(t=> t.Status == (int)Statuses.Ticket.Invalid).Count();
            if(countBuy>=1){
                buyingRatio += 0.5;
                if (countBuy >= 10)
                {
                    buyingRatio += 0.2;
                } else if(countBuy >= 50){
                    buyingRatio += 0.2;
                }
            }
            if (countTotalSell >= 1)
            {
                sellingRatio += 0.5;
                if (sellingRatio >= 10)
                {
                    sellingRatio += 0.2;
                }
                else if (sellingRatio >= 50)
                {
                    sellingRatio += 0.2;
                }
                sellingRatio *= ((double)(countTotalSell-countInvalidSell) / countTotalSell);
            }
            ratio = (sellingRatio + buyingRatio) / 2;
            double realRatio = ratio * maximumRating;
            double roundedRatio = Math.Round(realRatio * 100) / 100;
            return roundedRatio;
        }
    }
}