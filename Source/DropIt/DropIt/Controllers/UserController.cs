using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using System;
using System.Collections.Generic;
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
      

        public ActionResult Edit(int id = 0)
        {
            id = WebSecurity.GetUserId(User.Identity.Name);
            User user = this.unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                                user.ProvinceId);
            return View(user);
        }

        //
        // POST: /User/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                this.unitOfWork.UserRepository.AddOrUpdate(user);
                this.unitOfWork.UserRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ProvinceId = new SelectList(this.unitOfWork.ProvinceRepository.Get(), "ProvinceId", "ProvinceName",
                                                user.ProvinceId);
            return View(user);
        }
    }
}
