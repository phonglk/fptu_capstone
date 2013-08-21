using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.ViewModels;
using WebMatrix.WebData;
using DropIt.Common;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
      

        public ActionResult Edit(int id = 0)
        {
            id = WebSecurity.GetUserId(User.Identity.Name);
            User user = this.unitOfWork.UserRepository.GetById(id);
            UserViewModel newUser = new UserViewModel()
                                        {
                                            FullName = user.FullName,
                                            Email = user.Email,
                                            Phone = user.Phone,
                                            Address = user.Address,
                                            BankName = user.BankName,
                                            BankAccount = user.BankAccount,
                                            IdentityCard = user.IdentityCard                                            
                                        };            
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                                user.ProvinceId);
            return View(newUser);
        }

        public ActionResult Profile(int id = 0)
        {
            User user = this.unitOfWork.UserRepository.GetById(id);
            ViewBag.Success = user.Tickets1.Where(t=>t.TranStatus != null).Count();
            ViewBag.Invalid = this.unitOfWork.TicketRepository.Get(t => t.Status == (int)Statuses.Ticket.Invalid && t.UserId == user.UserId).Count();
            ViewBag.Rate = Utils.getUserRating(user);
            return View(user);
        }

        //
        // POST: /User/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            user.UserId = WebSecurity.GetUserId(User.Identity.Name);
            user.CreatedDate = unitOfWork.UserRepository.GetById(user.UserId).CreatedDate;
            if(ModelState.IsValid)
            {
                User newUser = new User()
                                            {
                                                UserId = user.UserId,       
                                                UserName = User.Identity.Name,
                                                FullName = user.FullName,
                                                Email = user.Email,
                                                Phone = user.Phone,
                                                Address = user.Address,
                                                BankAccount = user.BankAccount,
                                                BankName = user.BankName,
                                                IdentityCard = user.IdentityCard,
                                                ProvinceId = (int)user.ProvinceId,
                                                CreatedDate = user.CreatedDate
                                            };
                this.unitOfWork.UserRepository.AddOrUpdate(newUser);
                this.unitOfWork.UserRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                                user.ProvinceId);
            return View(user);
        }
    }
}
