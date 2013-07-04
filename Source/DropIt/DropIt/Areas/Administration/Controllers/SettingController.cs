using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Models;

namespace DropIt.Areas.Administration.Controllers
{
    public class SettingController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private SettingRepository Repository;

        public SettingController()
        {
            Repository = unitOfWork.SettingRepository;
        }
        //
        // GET: /Administration/Setting/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var setting = this.unitOfWork.SettingRepository.GetAll();
            return View(setting.ToList());
        }

        //Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                this.unitOfWork.SettingRepository.AddOrUpdate(setting);
                this.unitOfWork.SettingRepository.Save();
                return RedirectToAction("List");
            }
            return View(setting);
        }
    }
}
