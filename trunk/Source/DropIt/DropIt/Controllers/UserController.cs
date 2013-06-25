using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using DropIt.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Edit()
        {
            int id = WebSecurity.GetUserId(User.Identity.Name);
            User user = this.unitOfWork.UserRepository.GetById(id);
            UserViewModel newUser = new UserViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address
            };
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                                user.ProvinceId);
            return View(newUser);
        }

        //
        // POST: /User/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            user.UserName = User.Identity.Name;
            user.CreatedDate = unitOfWork.UserRepository.GetById(WebSecurity.GetUserId(user.UserName)).CreatedDate;
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Address = user.Address

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
